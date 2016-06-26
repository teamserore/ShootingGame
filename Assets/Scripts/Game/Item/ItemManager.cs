using UnityEngine;
using System.Collections;

public class ItemManager :MonoBehaviour {
    public ItemPool itemPool;
    public UIManager uiManager;
    public PlayerScript player;
    public GameObject bomb;

    int plusLife;
    int feverTimeCount;
    int plusPower;
    int feverPower;

    int powerCount =0;
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
        ReadyManager readyManager = GameObject.Find("ReadyManager").GetComponent<ReadyManager>();
        powerCount = readyManager.GetPowerItemCount();
        bombCount = readyManager.GetBombItemCount();
        uiManager.SetItemCountText(ItemType.POWER, powerCount);
        uiManager.SetItemCountText(ItemType.BOMB, bombCount);
        Destroy(GameObject.Find("ReadyManager"));

        DefSettingIO.getInstance.GetData("PlusLife", out plusLife);
        DefSettingIO.getInstance.GetData("FeverTimeCount", out feverTimeCount);
        DefSettingIO.getInstance.GetData("PlusPower", out plusPower);
        DefSettingIO.getInstance.GetData("FeverPower", out feverPower);

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
                player.SetPower(player.GetPower() + plusPower);
                uiManager.SetItemCountText(itemType, powerCount);
                break;
            case ItemType.BOMB:
                bombCount++;
                uiManager.SetItemCountText(itemType, bombCount);
                break;
            default:
                break;
        }
    }

    public void UseItem(ItemType itemType) {
        switch (itemType) {
            case ItemType.POWER:
                if (powerCount == 0) {
                    break;
                }
                powerCount--;
                uiManager.SetItemCountText(itemType, powerCount);
                UsePower();
                break;
            case ItemType.BOMB:
                if (bombCount == 0 || bomb.activeSelf) {
                    break;
                }
                bombCount--;
                uiManager.SetItemCountText(itemType, bombCount);
                UseBomb();
                break;
            default:
                break;
        }
    }

    public void UsePower() {
        StartCoroutine(FeverTime());
    }

    IEnumerator FeverTime() {
        int prePower = player.GetPower();
        player.SetPower(feverPower);
        yield return new WaitForSeconds(feverTimeCount);
        player.SetPower(prePower);
    }

    public void UseBomb() {
        bomb.SetActive(true);
        StartCoroutine(ClearMap());
    }

    IEnumerator ClearMap() {
        yield return new WaitForSeconds(0.01f);
        bomb.transform.Translate(new Vector3(0, 0.2f));
        if (bomb.transform.localPosition.y > 20) {
            bomb.SetActive(false);
            yield break;
        }
        StartCoroutine(ClearMap());
    }

    public void RemoveItem(GameObject gameObject) {
        itemPool.RemoveItemList(gameObject);
    }
}
