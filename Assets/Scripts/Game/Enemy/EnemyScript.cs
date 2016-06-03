using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    protected EnemyStruct enemyInfo;

    protected PlayerScript player;
	protected BoxCollider2D coll = null;

    // Wave에 따라 달라지는 것들.
    public ItemType itemType;
    public bool hasItem = false;

    void Start () 
	{
        coll = GetComponent<BoxCollider2D>(); 
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }

    protected void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player"){
			Die ();
		} 
		else if (coll.gameObject.tag == "PlayerBullet"){
			DownHP(player.getPlayerStruct().power); //에러
		}
	}

	protected void Die () {
		if(coll == null) {
			coll = GetComponent<BoxCollider2D>() ;
		}

		coll.enabled = false;
		transform.localScale = new Vector2 (transform.localScale.x - 0.01f, transform.localScale.y - 0.01f);
		EnemyManager.instance.DieEnemy(gameObject);
        if (hasItem) {
            ItemManager.instance.CreateItem(itemType, gameObject);
            Debug.Log("hasItem:true");
        }
        GameManager.instance.PlusCandy(enemyInfo.dropCandy);
        GameManager.instance.PlusScore();
	}

    protected void DownHP (int hp) {
		enemyInfo.hp -= hp;
		if (enemyInfo.hp < 0){
			enemyInfo.hp = 0;
		}
	}
}
