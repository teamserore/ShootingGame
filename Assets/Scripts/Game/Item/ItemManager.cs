using UnityEngine;
using System.Collections;

public class ItemManager :MonoBehaviour {
    ItemPool itemPool;
    UIManager uiManager;

    Item[] ItemList;
    int endPos = 0;
    int slotCount;

    void Start() {
        slotCount = PlayerPrefs.GetInt("SlotCount", 3);
        ItemList = new Item[slotCount];
    }

    public GameObject CreateItem(GameObject respawn) {
        int type = Random.Range(0, 2);
        return itemPool.NewItem(type, respawn);
    }

    public void GetItem(Item item, GameObject gameObject) {
        uiManager.AddItemToSlot(item, endPos);
        ItemList[endPos] = item;
        endPos++;

        gameObject.SetActive(false);
    }

    public void UseItem(int pos) {
        if (pos >= endPos)
            return;
        ItemList[pos].Use();
        ItemList[pos] = null;
        endPos--;
    }
}
