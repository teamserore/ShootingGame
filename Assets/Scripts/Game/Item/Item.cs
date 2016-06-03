using UnityEngine;
using System.Collections;

public enum ItemType {
    POWER,
    LIFE,
    BOMB
}

public class Item :MonoBehaviour {
    public ItemType itemType;

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            Item item = transform.gameObject.GetComponent<Item>();
            ItemManager.instance.GetItem(item.itemType);
        }
    }

    void Update() {
        transform.Translate(Vector2.down * Time.deltaTime * 1f);
    }
}
