using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager :MonoBehaviour {
   
    // InGameView
	Sprite PowerIcon;
    Sprite BombIcon;
    public GameObject playerHP;
    public GameObject InGameView;
    public GameObject PauseView;
    public GameObject ResultView;
    public Text tvCandy;
    public Text tvScore;
    public Text itemPowerCount;
    public Text itemBombCount;

    // Result View
    public Text tvResultCandy;
    public Text tvResultScore;
    public Text tvBestScore;
    public GameObject PlusCandyInGame;
    public Text tvPlusCandyInGame;

    public void UpPlayerHpSlider(int hp) {
        playerHP.transform.localScale += new Vector3(hp / 100f, 0, 0);
    }

    public void DownPlayerHpSlider(int hp) {
        playerHP.transform.localScale -= new Vector3(hp / 100f, 0, 0);
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

    public void SetPauseView(bool flag) {
        PauseView.SetActive(flag);
    }

    public void SetPlusCandy(bool flag) {
        PlusCandyInGame.SetActive(flag);
    }

    public void SetTextPlusCandy(int candy) {
        tvPlusCandyInGame.text = candy + " candy";
    }

    public void SetTextCandy(int candy) {
        tvCandy.text = candy + "";
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

    public void SetTextBestScore(int score) {
        tvBestScore.text = score + "";
    }
}
