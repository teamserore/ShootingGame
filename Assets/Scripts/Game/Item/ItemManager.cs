using UnityEngine;
using System.Collections;

public class ItemManager :MonoBehaviour {
    public ItemPool itemPool;
    public UIManager uiManager;
    PlayerScript player;

    int plusLife;
    int feverTimeCount;
    int plusPower;

    int powerCount=0;
    int bombCount=0;

    private static ItemManager _instance;

    public static ItemManager instance {
        get {
            return _instance;
        }
        set {
            value = _instance;
        }
    }
    void Awake() {
        _instance = this;
    }

    void Start() {
        DefSettingIO.getInstance.GetData("PlusLife", out plusLife);
        DefSettingIO.getInstance.GetData("FeverTimeCount", out feverTimeCount);
        DefSettingIO.getInstance.GetData("PlusPower", out plusPower);

        itemPool.Create();
        itemPool.AddItem();
    }

    public GameObject CreateItem(ItemType type, GameObject respawn) {
        return itemPool.NewItem(type, respawn);
    }

    public void GetItem(ItemType itemType) {
        switch (itemType) {
            case ItemType.POWER:
                powerCount++;
                uiManager.SetItemCountText(itemType, powerCount);
                break;
            case ItemType.LIFE:
                UseItem(ItemType.LIFE);
                break;
            case ItemType.BOMB:
                bombCount++;
                uiManager.SetItemCountText(itemType, bombCount);
                break;
            default:
                break;
        }
        itemPool.RemoveItemList(gameObject);
    }

    public void UseItem(ItemType itemType) {
        switch (itemType) {
            case ItemType.POWER:
                powerCount--;
                uiManager.SetItemCountText(itemType, powerCount);
                UsePower();
                break;
            case ItemType.LIFE:
                UseLife();
                break;
            case ItemType.BOMB:
                bombCount--;
                uiManager.SetItemCountText(itemType, bombCount);
                UseBomb();
                break;
            default:
                break;
        }
    }


    public void UseLife() {
        player.UpHP(plusLife);
    }

    public void UsePower() {
        StartCoroutine(FeverTime());
    }

    IEnumerator FeverTime() {
        player.UpPower(plusPower);
        yield return new WaitForSeconds(feverTimeCount);
        player.DownPower(plusPower - 1);
    }

    public void UseBomb() {
        // TODO(dhUM): 폭탄 사용 코드 처리
    }
}
