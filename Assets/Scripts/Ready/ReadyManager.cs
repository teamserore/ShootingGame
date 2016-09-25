using UnityEngine;
using System.Collections;

public class ReadyManager :MonoBehaviour {

    public TobBarManager topBarManager;
    public ReadyUIManager uiManager;

    int MAX_ITEM_COUNT = 3;

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
        //PlayerPrefs.SetInt("PowerLevel", 1);
        candy = PlayerPrefs.GetInt("Candy", 0);
        powerLevel = PlayerPrefs.GetInt("PowerLevel", 1);
		powerItemCount = PlayerPrefs.GetInt("PowerItemCount", 0);
		bombItemCount = PlayerPrefs.GetInt("BombItemCount", 0);

        DefSettingIO.getInstance.GetData("LifePrice", out lifePrice);
        DefSettingIO.getInstance.GetData("PowerPrice", out powerPrice);
        DefSettingIO.getInstance.GetData("BombPrice", out bombPrice);
        uiManager.SetPowerLevel(powerLevel);
        uiManager.SetPowerImage(powerLevel);
		uiManager.SetPowerItemCount(powerItemCount);
		uiManager.SetBombItemCount(bombItemCount);

        StatStruct nextData;
        StatIO.getInstance.GetStatData(powerLevel, out nextData);
        uiManager.SetPowerLevelPrice(nextData.candyForPower);
        PlayerPrefs.SetInt("HP", lifeItemCount);

        DontDestroyOnLoad(gameObject);


    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            MSceneManager.MainGo();
        }
    }

    public void GameGo() {
        if (SoundEffectManager.instance != null) {
            SoundEffectManager.instance.PlayButtonClickSound();
        }
        DontDestroyOnLoad(this.gameObject);
        MSceneManager.GameGo();
    }

    // 공격력 레벨업
    public void levelUpPower() {
        StatStruct curData;
        StatIO.getInstance.GetStatData(powerLevel, out curData);

        if (powerLevel >= 10)
            return;

        if (checkCandy(curData.candyForPower))
        {
            if (SoundEffectManager.instance != null)
            {
                SoundEffectManager.instance.PlayButtonClickSound();
            }
            

            minusCandy(curData.candyForPower);
            powerLevel++;
            PlayerPrefs.SetInt("PowerLevel", powerLevel);
            uiManager.SetPowerLevel(powerLevel);

            StatStruct nextData;
            StatIO.getInstance.GetStatData(powerLevel, out nextData);
            uiManager.SetPowerLevelPrice(nextData.candyForPower);
            uiManager.SetPowerImage(powerLevel);
        }
    }

    public void BuyLifeItem() {
        if (checkCandy(lifePrice) && lifeItemCount == 1) {
            if (SoundEffectManager.instance != null) {
                SoundEffectManager.instance.PlayButtonClickSound();
            }
            minusCandy(lifePrice);
            lifeItemCount++;
            PlayerPrefs.SetInt("HP", lifeItemCount);
            uiManager.SetLifeItemCount(lifeItemCount-1);
        }
    }

    public void BuyPowerItem() {
        if (checkCandy(powerPrice) && powerItemCount < MAX_ITEM_COUNT) {
            if (SoundEffectManager.instance != null) {
                SoundEffectManager.instance.PlayButtonClickSound();
            }
            minusCandy(powerPrice);
            powerItemCount++;
            uiManager.SetPowerItemCount(powerItemCount);
			PlayerPrefs.SetInt("PowerItemCount", powerItemCount);
        }
    }

    public void BuyBombItem() {
        if (checkCandy(bombPrice) && bombItemCount < MAX_ITEM_COUNT) {
            if (SoundEffectManager.instance != null) {
                SoundEffectManager.instance.PlayButtonClickSound();
            }
            minusCandy(bombPrice);
            bombItemCount++;
            uiManager.SetBombItemCount(bombItemCount);
			PlayerPrefs.SetInt("BombItemCount", bombItemCount);
        }
    }

    private void minusCandy(int candy) {
        this.candy -= candy;
        PlayerPrefs.SetInt("Candy", this.candy);
        topBarManager.SetTextCandy(this.candy);
    }

    private bool checkCandy(int candy) {
        if (this.candy < candy) {
            return false;
        }
        return true;
    }

    public int GetPowerItemCount() {
        return powerItemCount;
    }

    public int GetBombItemCount() {
        return bombItemCount;
    }
}
