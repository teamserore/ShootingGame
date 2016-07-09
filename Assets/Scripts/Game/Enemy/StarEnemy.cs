using UnityEngine;
using System.Collections;

public class StarEnemy : EnemyScript {
	protected BoxCollider2D coll = null;

	void Start () {
        EnemyIO.getInstance.GetEnemyData(EnemyType.StarEnemy, out enemyInfo);

	}

	void Awake(){
		coll = GetComponent<BoxCollider2D> ();
		coll.enabled = true;
	}

	public void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			Die();
		} else if (coll.gameObject.tag == "PlayerBullet") {
			//DownHP(10); // Need to fix it
			Die();
		} else if (coll.gameObject.tag == "Bomb") {
			Die();
		}
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
