using UnityEngine;
using System.Collections;

public class PlayerBullet : MonoBehaviour{

    private BulletStruct bulletInfo;
    private BoxCollider2D coll = null;
    private GameManager gameManager = null;

    void Start () {
        DefSettingIO.getInstance.GetData("BulletSpeed", out bulletInfo.speed);
    }

    void Enable() {
        coll.enabled = true;
    }


    void Awake() {
        coll = GetComponent<BoxCollider2D>(); // BoxCollider2D
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }


    void Update () {
        transform.Translate(Vector2.up * bulletInfo.speed * Time.deltaTime);

        if (transform.position.y >= 10) {
            coll.enabled = false;
            gameObject.SetActive(false);
        }
    }

    bool OnTriggerEnter2D(Collider2D coll) {
        if(coll.gameObject.tag == "Enemy") {
            coll.enabled = false;
            gameObject.SetActive(false);
            gameManager.PlusCandy(coll.gameObject.GetComponent<EnemyScript>().getEnemyStruct().dropCandy);
            return true;
        }
        return false;
    }
}
