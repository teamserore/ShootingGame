using UnityEngine;
using System.Collections;

public enum ItemType {
    POWER,
    BOMB
}

public class Item :MonoBehaviour {
    public ItemType itemType;
    protected BoxCollider2D coll = null;

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            Item item = transform.gameObject.GetComponent<Item>();
            ItemManager.instance.GetItem(item.itemType);
            ItemManager.instance.RemoveItem(gameObject);
        }
    }

    void OnEnable() {
        coll = GetComponent<BoxCollider2D>();
        coll.enabled = true;
    }

    void Update() {
        transform.Translate(Vector2.down * Time.deltaTime * 1f);
    }
}
