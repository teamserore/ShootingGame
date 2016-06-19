using UnityEngine;
using System.Collections;

public class ReadyManager :MonoBehaviour {

    public TobBarManager topBarManager;
    public ReadyUIManager uiManager;

    // 사용자의 현재 레벨과 슬롯 수
    int candy;
    int powerLevel;

    // 1회용 아이템 가격
    int powerPrice;
    int lifePrice;
    int bombPrice;

    int powerItemCount = 0;
    int lifeItemCount = 1;
    int bombItemCount = 0;

    void Start() {
        candy = PlayerPrefs.GetInt("Candy", 500);
        powerLevel = PlayerPrefs.GetInt("PowerLevel", 1);
        DefSettingIO.getInstance.GetData("LifePrice", out lifePrice);
        DefSettingIO.getInstance.GetData("PowerPrice", out powerPrice);
        DefSettingIO.getInstance.GetData("BombPrice", out bombPrice);
        uiManager.SetPowerLevel(powerLevel);
        uiManager.SetPowerImage(powerLevel);
        PlayerPrefs.SetInt("HP", lifeItemCount);
        DontDestroyOnLoad(gameObject);
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

    // 공격력 레벨업
    public void levelUpPower() {
        StatStruct curData;
        StatIO.getInstance.GetStatData(powerLevel, out curData);

        if (minusCandy(curData.candyForPower)) {
            SoundEffectManager.instance.PlayButtonClickSound();
            powerLevel++;
            PlayerPrefs.SetInt("PowerLevel", powerLevel);
            uiManager.SetPowerLevel(powerLevel);

            StatStruct nextData;
            StatIO.getInstance.GetStatData(powerLevel, out nextData);
            uiManager.SetPowerLevelPrice(nextData.candyForPower);

            uiManager.SetPowerImage(powerLevel);
        }
    }

    // 생명 아이템
    public void BuyLifeItem() {
        if (minusCandy(lifePrice) && lifeItemCount < 1) {
            SoundEffectManager.instance.PlayButtonClickSound();
            lifeItemCount++;
            PlayerPrefs.SetInt("HP", lifeItemCount);
            uiManager.SetLifeItemCount(lifeItemCount-1);
        }
    }

    public void BuyPowerItem() {
        if (minusCandy(powerPrice) && powerItemCount < 3) {
            SoundEffectManager.instance.PlayButtonClickSound();
            powerItemCount++;
            uiManager.SetPowerItemCount(powerItemCount);
        }
    }

    public void BuyBombItem() {
        if (minusCandy(bombPrice) && bombItemCount < 3) {
            SoundEffectManager.instance.PlayButtonClickSound();
            bombItemCount++;
            uiManager.SetBombItemCount(bombItemCount);
        }
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

    public int GetPowerItemCount() {
        return powerItemCount;
    }

    public int GetBombItemCount() {
        return bombItemCount;
    }
}
