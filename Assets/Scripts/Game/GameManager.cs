using UnityEngine;
using System.Collections;

public enum GameState {
    Play,
    Pause,
    End
}

public class GameManager :MonoBehaviour {

    public GameState GS;
    public UIManager uiManager;
    int candy = 0;
    int score = 0;
    int time;  // TODO(dhUM): time에 관한 처리는 나중에 한다.

	private static GameManager _instance;

	public static GameManager instance {
		get {
			return _instance;
		}
		set {
			value = _instance;
		}
	}
	void Awake()
	{
		_instance = this;
	}

    void Start() {
        candy = PlayerPrefs.GetInt("Candy", 500);
        uiManager.SetTextCandy(candy);
        uiManager.SetTextScore(score);
        StartCoroutine(PlusTime());
    }

    int ComputeScore(int score) {
        // TODO(dhUM): 점수 보정은 나중에 변경
        if (60 < time && time < 120) {
            score *= 2;
        } else if (120 < time && time < 180) {
            score *= 3;
        } else {
            score *= 4;
        }
        return score;
    }


    public void GameOver() {
        GS = GameState.End;

        score = ComputeScore(score);

        uiManager.SetInGameView(false);
        uiManager.SetResultView(true);
        uiManager.SetTextResultCandy(candy);
        // player.SetActive(true);

        int bestScore = PlayerPrefs.GetInt("BestScore", 10000);
        if (score > bestScore) {
            PlayerPrefs.SetInt("BestScore", score);
        }
        uiManager.SetTextBestScore(bestScore);

        PlayerPrefs.SetInt("Candy", candy);
    }

    public void Replay() {
        candy = PlayerPrefs.GetInt("Candy", 0);
        score = 0;
        MSceneManager.GameGo();
    }

    public void MainGo() {
        MSceneManager.MainGo();
    }

    public void Pause() {
        Time.timeScale = 0;
        GS = GameState.Pause;
        uiManager.SetPauseView(true);
    }

    public void UnPause() {
        Time.timeScale = 1;
        GS = GameState.Play;
        uiManager.SetPauseView(false);
    }

    public void PlusScore() {
        // TODO(dhUM): 시간대별로 점수 더하기.
        score += 100;
        uiManager.SetTextScore(score);
    }

    public IEnumerator PlusCandy(int plusCandy) {
        candy += plusCandy;
        uiManager.SetTextCandy(candy);

        uiManager.SetTextPlusCandy(candy);
        uiManager.SetPlusCandy(true);
        yield return new WaitForSeconds(2f);
        uiManager.SetPlusCandy(false);
    }

    public IEnumerator PlusTime() {
        yield return new WaitForSeconds(1f);
        time += 1;
        //TODO(dhUM): time 관련 UI 셋팅이 필요
    }

    public void UseItem(ItemType itemType) {
        ItemManager.instance.UseItem(itemType);
    }
}
