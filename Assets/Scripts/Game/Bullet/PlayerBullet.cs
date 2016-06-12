using UnityEngine;
using System.Collections;

public class PlayerBullet : BulletScript {

	void Start () {
        base.bulletInfo.speed = 15.0f;
        //base.bulletInfo.power = StaticObject.playerPower;
        
    }

    void Update () {
        transform.Translate(Vector2.up * base.bulletInfo.speed * Time.deltaTime);

        if (transform.position.y >= 20) {
            this.Die();
        }
    }

    bool OnTriggerEnter2D(Collider2D coll) //피격처리
    {
        if(coll.gameObject.tag == "Enemy") {
            this.Die();
            Debug.Log("총알 에너미 접촉");
            return true;
        }
        return false;
    }

    void Die()
    {
        coll.enabled = false;
        transform.localScale = new Vector2(transform.localScale.x - 0.01f, transform.localScale.y - 0.01f);
        gameObject.SetActive(false);
        gameManager.PlusCandy(enemyInfo.dropCandy);
    }
}
