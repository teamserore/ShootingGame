using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum PopupKind {
    POWER,
    LIFE,
}

public class ReadyManager :MonoBehaviour {

    public TobBarManager topBarManager;
    public ReadyUIManager uiManager;

    // 사용자의 현재 레벨과 슬롯 수
    int candy;
    int powerLevel;
    int lifeLevel;

    // 1회용 아이템 가격
    int powerPrice;
    int bombPrice;

    public bool isGetPower = false;
    public bool isGetBomb = false;

    PopupKind popupKind;

    void Start() {
        candy = PlayerPrefs.GetInt("Candy", 500);
        powerLevel = PlayerPrefs.GetInt("PowerLevel", 1);
        lifeLevel = PlayerPrefs.GetInt("LifeLevel", 1);

        DefSettingIO.getInstance.GetData("PowerPrice", out powerPrice);
        DefSettingIO.getInstance.GetData("BombPrice", out bombPrice);

    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            MSceneManager.MainGo();
        }
    }

    public void GameGo() {
        SoundEffectManager.instance.PlayButtonClickSound();
        DontDestroyOnLoad(this.gameObject);
        MSceneManager.GameGo();
    }

    // 공격력 레벨업 시도
    public void levelUpPower() {
        StatStruct tempData;
        StatIO.getInstance.GetStatData(powerLevel + 1, out tempData);

        popupKind = PopupKind.POWER;
        uiManager.ShowPopup(tempData.candyForPower);
    }

    // 생명력 레벨업 시도
    public void levelUpLife() {
        StatStruct tempData;
        StatIO.getInstance.GetStatData(lifeLevel + 1, out tempData);

        popupKind = PopupKind.LIFE;
        uiManager.ShowPopup(tempData.candyForLife);
    }

    // 확인
    public void OK() {
        SoundEffectManager.instance.PlayButtonClickSound();
        switch (popupKind) {
            case PopupKind.POWER:
                StatStruct tempData1;
                StatIO.getInstance.GetStatData(powerLevel + 1, out tempData1);
                if (minusCandy(tempData1.candyForPower)) {
                    powerLevel++;
                    PlayerPrefs.SetInt("PowerLevel", powerLevel);
                }
                break;
            case PopupKind.LIFE:
                StatStruct tempData2;
                StatIO.getInstance.GetStatData(lifeLevel + 1, out tempData2);
                if (minusCandy(tempData2.candyForLife)) {
                    lifeLevel++;
                    PlayerPrefs.SetInt("LifeLevel", lifeLevel);
                }
                break;

        }
        uiManager.dismissPopup();
    }

    public void Cancel() {
        SoundEffectManager.instance.PlayButtonClickSound();
        uiManager.dismissPopup();
    }

    // 일회용 아이템(파워,폭탄) 구매 
    public void BuyItem(int type) {
        SoundEffectManager.instance.PlayButtonClickSound();
        switch ((ItemType)type) {
            case ItemType.POWER:
                if (minusCandy(powerPrice)) {
                    isGetPower = true;
                }
                break;
            case ItemType.BOMB:
                if (minusCandy(bombPrice)) {
                    isGetBomb = true;
                }
                break;
        }
    }


    private void plusCandy(int candy) {
        this.candy += candy;
        PlayerPrefs.SetInt("Candy", this.candy);
        topBarManager.SetTextCandy(candy);
    }

    private bool minusCandy(int candy) {
        if (this.candy < candy) {
            return false;
        }
        this.candy -= candy;
        PlayerPrefs.SetInt("Candy", this.candy);
        topBarManager.SetTextCandy(candy);
        return true;
    }
}
