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
    int time = 0;

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
        if (BgmManager.instance != null) {
            BgmManager.instance.PlayGameBgm(1);
        }
        candy = PlayerPrefs.GetInt("Candy", 100000);
        GS = GameState.Play;
        uiManager.SetTextCandy(candy);
        uiManager.SetTextScore(score);
        StartCoroutine(PlusTime());
    }

    public GameState getGameState() {
        return GS;
    }

    public void GameOver() {
        GS = GameState.End;
        Time.timeScale = 0;
        uiManager.SetInGameView(false);
        uiManager.SetResultView(true);
        uiManager.SetTextResultCandy(candy);
        PlayerPrefs.SetInt("Candy", candy);
        uiManager.SetTextResultTime(time);
        uiManager.SetTextResultScore(score);

        int score1 = PlayerPrefs.GetInt("Score1", 0);
        int score2 = PlayerPrefs.GetInt("Score2", 0);
        int score3 = PlayerPrefs.GetInt("Score3", 0);
        if (score > score1) {
            score3 = score2;
            score2 = score1;
            score1 = score;
        } else if (score > score2) {
            score3 = score2;
            score2 = score;
        } else if (score > score3) {
            score3 = score;
        }
        uiManager.SetTextRank(score1, score2, score3);
        PlayerPrefs.SetInt("Score1", score1);
        PlayerPrefs.SetInt("Score2", score2);
        PlayerPrefs.SetInt("Score3", score3);

    }

    public void Replay() {
        SoundEffectManager.instance.PlayButtonClickSound();
        candy = PlayerPrefs.GetInt("Candy", 0);
        score = 0;
        MSceneManager.GameGo();
    }

    public void MainGo() {
        if(SoundEffectManager.instance != null)
        SoundEffectManager.instance.PlayButtonClickSound();
        MSceneManager.MainGo();
    }

    public void PlusScore() {
        score += 100;
        uiManager.SetTextScore(score);
    }

    public void PlusCandy(int plusCandy) {
        candy += plusCandy;
        uiManager.SetTextCandy(candy);
        StartCoroutine(PopupPlusCandy(plusCandy));
    }

    public IEnumerator PopupPlusCandy(int plusCandy) {
        uiManager.SetTextPlusCandy(plusCandy);
        uiManager.SetPlusCandy(true);
        yield return new WaitForSeconds(2f);
        uiManager.SetPlusCandy(false);
    }

    public IEnumerator PlusTime() {
        while (GS != GameState.End) {
            yield return new WaitForSeconds(1f);
            time += 1;
        }
    }

    public void UseItem(ItemType itemType) {
        ItemManager.instance.UseItem(itemType);
    }
}
