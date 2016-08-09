using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadyUIManager : MonoBehaviour {
    public Text powerLevel;
    public Text powerPrice;
    public Image powerImage;
    public Sprite[] powerImageList = new Sprite[11];

    // Item
    public Text lifeItemCount;
    public Text lifeItemPrice;
    public Text powerItemCount;
    public Text powerItemPrice;
    public Text bombItemCount;
    public Text bombItemPrice;

    void Start() {
        int lifePrice;
        int powerPrice;
        int bombPrice;
        DefSettingIO.getInstance.GetData("LifePrice", out lifePrice);
        DefSettingIO.getInstance.GetData("PowerPrice", out powerPrice);
        DefSettingIO.getInstance.GetData("BombPrice", out bombPrice);
        lifeItemPrice.text = lifePrice + "";
        powerItemPrice.text = powerPrice + "";
        bombItemPrice.text = bombPrice + "";
    }

    /** Power Level */
    public void SetPowerLevel(int level) {

        if (level == 10) {
            powerLevel.text = "Lv. MAX";
            return;
        }
        powerLevel.text = "Lv. " + level;
    }

    public void SetPowerLevelPrice(int price) {
        powerPrice.text = price + "";
    }

    public void SetPowerImage(int level) {
        powerImage.sprite = powerImageList[level-1];
    }

    /** Item */
    public void SetLifeItemCount(int count) {
        if (count == 1) {
            lifeItemCount.text = "x MAX";
            return;
        }
        lifeItemCount.text = "x" + count;
    }

    public void SetPowerItemCount(int count) {
        if (count == 3) {
            powerItemCount.text = "x MAX";
            return;
        }
        powerItemCount.text = "x" + count;
    }

    public void SetBombItemCount(int count) {
        if (count == 3) {
            bombItemCount.text = "x MAX";
            return;
        }
        bombItemCount.text = "x" + count;
    }
}
