using UnityEngine;
using System.Collections;

public class StarEnemy : EnemyScript {

	// Use this for initialization
	void Start () {
		enemyInfo.index = 0;
		enemyInfo.hp = 1;
		enemyInfo.power = 3;
		enemyInfo.speed = 9;
		enemyInfo.dropCandy = 1;
	}

	void Awake(){
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}
				
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.down * Time.deltaTime * enemyInfo.speed); // move down
		if (enemyInfo.hp <= 0) {
			Die ();
		}	
		else if (transform.position.y <= -10) {
			Die ();
		}
	}
}
