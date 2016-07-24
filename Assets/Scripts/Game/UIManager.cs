using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager :MonoBehaviour {

    public TobBarManager topBarManager;
    // InGameView
    public GameObject InGameView;
    public Text tvScore;
    public Text itemPowerCount;
    public Text itemBombCount;

    // Result View
    public GameObject ResultView;
    public Text tvResultCandy;
    public Text tvResultScore;
    public Text tvResultTime;
    public Text tvRank1;
    public Text tvRank2;
    public Text tvRank3;
    public GameObject PlusCandyInGame;
    public Text tvPlusCandyInGame;
   

    void Start() {
        tvScore.text = PlayerPrefs.GetInt("BestScore", 3) + "";
    }

    public void SetItemCountText(ItemType itemType, int count) {
        switch (itemType) {
            case ItemType.POWER:
                itemPowerCount.text = count + "";
                break;
            case ItemType.BOMB:
                itemBombCount.text = count + "";
                break;
            default:
                break;
        }
    }

    public void UseItem(int itemType) {
        GameManager.instance.UseItem((ItemType)itemType);
    }

    public void SetInGameView(bool flag) {
        InGameView.SetActive(flag);
    }

    public void SetResultView(bool flag) {
        ResultView.SetActive(flag);
    }

    public void SetPlusCandy(bool flag) {
        PlusCandyInGame.SetActive(flag);
    }

    public void SetTextPlusCandy(int candy) {
        tvPlusCandyInGame.text = candy + " candy";
    }

    public void SetTextCandy(int candy) {
        topBarManager.SetTextCandy(candy);
    }

    public void SetTextScore(int score) {
        tvScore.text = score + "";
    }

    public void SetTextResultCandy(int candy) {
        tvResultCandy.text = candy + "";
    }

    public void SetTextResultScore(int score) {
        tvResultScore.text = score + "";
    }

    public void SetTextResultTime(int time) {
        // TODO(dhUm): time 예쁘게 출력..
        tvResultTime.text = time + "초";
    }

    public void SetTextRank(int score1, int score2, int score3) {
        tvRank1.text = score1 + "";
        tvRank2.text = score2 + "";
        tvRank3.text = score3 + "";
    }
}