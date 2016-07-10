using UnityEngine;
using System.Collections;

public class StarEnemy : EnemyScript {
	private int hp;

	void Start () {
        EnemyIO.getInstance.GetEnemyData(EnemyType.StarEnemy, out enemyInfo);
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
