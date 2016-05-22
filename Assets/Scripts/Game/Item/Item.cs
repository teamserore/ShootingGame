using UnityEngine;
using System.Collections;

public class Item :MonoBehaviour {
    protected PlayerScript player;
    protected UIManager uiManager;
    ItemManager itemManager;

    public void Use() {

    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Player") {
            itemManager.GetItem(transform.gameObject.GetComponent<Item>(), this.gameObject);
        }
    }

    void Update() {
        transform.Translate(Vector2.down * Time.deltaTime * 2f);
    }
}
