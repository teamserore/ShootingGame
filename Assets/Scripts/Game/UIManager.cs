using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager :MonoBehaviour {

    // InGameView
    public GameObject InGameView;
    public Slider hpSlider;
    public Text tvCandy;
    public Text tvScore;
    public Text itemPowerCount;
    public Text itemBombCount;

    // PauseView, SettingView
    public GameObject PauseView;
    public GameObject SettingView;
    public Slider soundSlider;
    public Slider bgmSlider;

    // Result View
    public GameObject ResultView;
    public Text tvResultCandy;
    public Text tvResultScore;
    public Text tvBestScore;
    public GameObject PlusCandyInGame;
    public Text tvPlusCandyInGame;

    public void Start() {
       /* soundSlider.onValueChanged.AddListener(delegate {
            SoundValueChaned();
        });
        bgmSlider.onValueChanged.AddListener(delegate {
            BgmValueChaned();
        });
        */
    }

    public void SoundValueChaned() {
        Debug.Log("a");
    }

    public void BgmValueChaned() {
        Debug.Log("b");
    }

    public void UpPlayerHpSlider(int hp) {
        hpSlider.value += hp / 100f;
    }

    public void DownPlayerHpSlider(int hp) {
        hpSlider.value -= hp / 100f;
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

    public void SetPasueView(bool flag) {
        PauseView.SetActive(flag);
    }

    public void SetSettingView(bool flag) {
        SettingView.SetActive(flag);
    }
}
