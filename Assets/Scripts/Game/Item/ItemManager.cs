using UnityEngine;
using System.Collections;

public class ItemManager :MonoBehaviour {
    public ItemPool itemPool;
    public UIManager uiManager;
    public PlayerScript player;
    public GameObject bomb;
    public PlayerBulletPool playerBulletPool;

    int plusLife;
    int feverTimeCount;
    int plusPower;
    int feverPower;

    int powerCount =0;
    int bombCount=0;

    int MAX_ITEM_COUNT = 3;

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
		/*
        ReadyManager readyManager = GameObject.Find("ReadyManager").GetComponent<ReadyManager>();
        powerCount = readyManager.GetPowerItemCount();
        bombCount = readyManager.GetBombItemCount();
        */
		powerCount = PlayerPrefs.GetInt("PowerItemCount", 0);
		bombCount = PlayerPrefs.GetInt("BombItemCount", 0);

		PlayerPrefs.SetInt("PowerItemCount", 0);
		PlayerPrefs.SetInt("BombItemCount", 0);

		uiManager.SetItemCountText(ItemType.POWER, powerCount);
        uiManager.SetItemCountText(ItemType.BOMB, bombCount);
        //Destroy(GameObject.Find("ReadyManager"));

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

    public void CheckPowerItem()
    {
        if (powerCount > 0)
        {
            player.SetPower(player.GetPower() + plusPower);
        }
    }

    public int ReturnPowerCount()
    {
        return powerCount;
    }

    public void GetItem(ItemType itemType) {
        if (SoundEffectManager.instance != null) {
            SoundEffectManager.instance.PlayGetItemSound();
        }
        switch (itemType) {
            case ItemType.POWER:
                if (powerCount >= MAX_ITEM_COUNT) {
                    return;
                }
                powerCount++;
                player.SetPower(player.GetPower() + plusPower);
                uiManager.SetItemCountText(itemType, powerCount);
                //playerBulletPool.StopAllCoroutines();
                //코루틴 재시작
                //StartCoroutine(playerBulletPool.CreatePlayerBullet(playerBulletPool.CheckPowerLv(player.GetPower())));
			playerBulletPool.UpgradeLevel();
                break;
            case ItemType.BOMB:
                if (bombCount >= MAX_ITEM_COUNT) {
                    return;
                }
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
                if (powerCount == 0 || playerBulletPool.ReturnCurrentPower() == 11)
                {
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
        if (SoundEffectManager.instance != null) {
            SoundEffectManager.instance.PlayUsePowerItemSound();
        }
        //TODO(SHBoo)캐릭터 파워수정, 코루틴 호출
        StartCoroutine(FeverTime());
    }

	IEnumerator FeverTime() {
		int prevLevel = playerBulletPool.ReturnCurrentPower();
        print("prev : " + prevLevel);
		playerBulletPool.MaxPower();
		yield return new WaitForSeconds(feverTimeCount);
		playerBulletPool.DowngradeLevel(prevLevel);
	}
	
	/*IEnumerator FeverTime() {
        int prePower = player.GetPower();
        player.SetPower(feverPower);
        yield return new WaitForSeconds(feverTimeCount);
        player.SetPower(prePower);
    }*/

    public void UseBomb() {
        if (SoundEffectManager.instance != null) {
            SoundEffectManager.instance.PlayUseBombItemSound();
        }
        bomb.SetActive(true);
        StartCoroutine(ClearMap());
    }

    IEnumerator ClearMap() {
        yield return new WaitForSeconds(0.01f);
        bomb.transform.Translate(new Vector3(0, 0.2f));
        if (bomb.transform.localPosition.y > 20) {
            bomb.SetActive(false);
            bomb.transform.Translate(new Vector3(0, -40f));
            yield break;
        }
        StartCoroutine(ClearMap());
    }

    public void RemoveItem(GameObject gameObject) {
        itemPool.RemoveItemList(gameObject);
    }
}
