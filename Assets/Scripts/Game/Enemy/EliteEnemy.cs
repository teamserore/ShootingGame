using UnityEngine;
using System.Collections;

public class EliteEnemy : EnemyScript {
	private int hp;

	// Use this for initialization
	void Start () {
		EnemyIO.getInstance.GetEnemyData (EnemyType.EleteEnemy, out enemyInfo);
		hp = enemyInfo.hp;
	}

	void OnEnable() {
		hp = enemyInfo.hp;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.down * Time.deltaTime * enemyInfo.speed); // move down
		if (hp <= 0) {
			Die ();
		}	
		else if (transform.position.y <= -10) {
			Die ();
		}
	}
}
