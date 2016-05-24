using UnityEngine;
using System.Collections;

public class PirateEnemy : EnemyScript {
	private int count = 0;

	// Use this for initialization
	void Start () {
		enemyInfo.index = 3;
		enemyInfo.hp = 1;
		enemyInfo.power = 3;
		enemyInfo.speed = 9;
		enemyInfo.dropCandy = 1;
	}

	void Awake(){
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update (){
		count++;
		if (count < 40) {
			transform.Translate (Vector2.down * Time.deltaTime * enemyInfo.speed); // move down
		} else if (count == 40) {
			//Instantiate (enemyBullet, this.transform.position, Quaternion.identity);
		} else if (count == 50) {
			//Instantiate (enemyBullet, this.transform.position, Quaternion.identity);
		} else if (count > 100) {
			transform.Translate (Vector2.down * Time.deltaTime * enemyInfo.speed); // move down
		}
		if (enemyInfo.hp <= 0) {
			Die ();
		} else if (transform.position.y <= -10) {
			Die ();
		}
	}
}
