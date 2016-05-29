using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

    protected EnemyStruct enemyInfo;
    protected PlayerScript player;
	protected ItemManager itemManager;
	protected BoxCollider2D coll = null;
    GameManager gameManager;
    
	void Start () 
	{
        coll = GetComponent<BoxCollider2D>(); 
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
        gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();

    }

    protected void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player"){
			Die ();
		} 
		else if (coll.gameObject.tag == "Bullet"){
			DownHP(player.getPlayerStruct().power);
		}
	}

	protected void Die () {
		coll.enabled = false;
		transform.localScale = new Vector2 (transform.localScale.x - 0.01f, transform.localScale.y - 0.01f);
        EnemyManager.instance.DieEnemy(gameObject);
        gameManager.PlusCandy(enemyInfo.dropCandy);
        //GameManager.instance.PlusScore(enemyInfo.score);
    }

    protected void DownHP (int hp) {
		enemyInfo.hp -= hp;
		if (enemyInfo.hp < 0){
			enemyInfo.hp = 0;
		}
	}
}
