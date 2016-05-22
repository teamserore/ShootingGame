using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum PopupKind {
    POWER,
    LIFE,
    SLOT
}

public class ReadyManager :MonoBehaviour {

    public ReadyUIManager uiManager;

    // 사용자의 현재 레벨과 슬롯 수
    int candy;
    int powerLevel;
    int lifeLevel;
    int slotCount;

    // 1회용 아이템 가격
    int lifePrice;
    int powerPrice;
    int bombPrice;
    int slotPrice;

    public bool isGetPower = false;
    public bool isGetLife = false;
    public bool isGetBomb = false;

    PopupKind popupKind;

    void Start() {
        candy = PlayerPrefs.GetInt("Candy", 500);
        powerLevel = PlayerPrefs.GetInt("PowerLevel", 1);
        lifeLevel = PlayerPrefs.GetInt("LifeLevel", 1);
        slotCount = PlayerPrefs.GetInt("SlotCount", 3);
        uiManager.SetPlayerName(PlayerPrefs.GetString("UserName", "새로이"));
        uiManager.SetPalyerCandy(candy);
        uiManager.SetSlot(slotCount);

        DefSettingIO.getInstance.GetData("PowerPrice", out powerPrice);
        DefSettingIO.getInstance.GetData("LifePrice", out lifePrice);
        DefSettingIO.getInstance.GetData("BombPrice", out bombPrice);
        DefSettingIO.getInstance.GetData("SlotPrice", out slotPrice);
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            MSceneManager.MainGo();
        }
    }

    public void GameGo() {
        DontDestroyOnLoad(this.gameObject);
        MSceneManager.GameGo();
    }

    // 공격력 레벨업 시도
    public void addPower() {
        StatStruct tempData;
        StatIO.getInstance.GetStatData(powerLevel + 1, out tempData);

        popupKind = PopupKind.POWER;
        uiManager.ShowPopup(tempData.candyForPower);
    }

    // 생명력 레벨업 시도
    public void addLife() {
        StatStruct tempData;
        StatIO.getInstance.GetStatData(lifeLevel + 1, out tempData);

        popupKind = PopupKind.LIFE;
        uiManager.ShowPopup(tempData.candyForLife);
    }

    // 슬롯을 확장 시도
    public void AppendSlot() {
        popupKind = PopupKind.SLOT;
        uiManager.ShowPopup(slotPrice);
    }

    // 확인
    public void OK() {
        switch (popupKind) {
            case PopupKind.POWER:
                StatStruct tempData1;
                StatIO.getInstance.GetStatData(powerLevel + 1, out tempData1);
                if (minusCandy(tempData1.candyForPower)) {
                    powerLevel++;
                    PlayerPrefs.SetInt("LifeLevel", powerLevel);
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
            case PopupKind.SLOT:
                if (minusCandy(slotPrice)) {
                    slotCount++;
                    uiManager.SetSlot(slotCount);
                    PlayerPrefs.SetInt("SlotCount", slotCount);
                }
                break;

        }
        uiManager.CancelPopup();
    }

    public void Cancel() {
        uiManager.CancelPopup();
    }

    // 일회용 아이템(파워,생명,폭탄) 구매 
    public void BuyItem(int type) {
        switch ((ItemType)type) {
            case ItemType.POWER:
                if (minusCandy(powerPrice)) {
                    uiManager.SetActiveItem(ItemType.POWER, false);
                    isGetPower = true;
                }
                break;
            case ItemType.LIFE:
                if (minusCandy(lifePrice)) {
                    uiManager.SetActiveItem(ItemType.LIFE, false);
                    isGetLife = true;
                }
                break;
            case ItemType.BOMB:
                if (minusCandy(bombPrice)) {
                    uiManager.SetActiveItem(ItemType.BOMB, false);
                    isGetBomb = true;
                }
                break;
        }
    }
    // 일회용 아이템(파워,생명,폭탄) 구매 취소
    public void CancelItem(int type) {
        switch ((ItemType)type) {
            case ItemType.POWER:
                plusCandy(powerPrice);
                uiManager.SetActiveItem(ItemType.POWER, true);
                isGetPower = false;
                break;
            case ItemType.LIFE:
                plusCandy(lifePrice);
                uiManager.SetActiveItem(ItemType.LIFE, true);
                isGetLife = false;
                break;
            case ItemType.BOMB:
                plusCandy(bombPrice);
                uiManager.SetActiveItem(ItemType.BOMB, true);
                isGetBomb = false;
                break;
        }
    }

    private void plusCandy(int candy) {
        this.candy += candy;
        //PlayerPrefs.SetInt("Candy", this.candy);
        uiManager.SetPalyerCandy(candy);
    }

    private bool minusCandy(int candy) {
        if (this.candy < candy) {
            return false;
        }
        this.candy -= candy;
        //PlayerPrefs.SetInt("Candy", this.candy);
        uiManager.SetPalyerCandy(candy);
        return true;
    }
}
