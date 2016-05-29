using UnityEngine;
using System.Collections;

public class StarEnemy : EnemyScript {
    
	void Start () {
        EnemyIO.getInstance.GetEnemyData(EnemyType.StarEnemy, out enemyInfo);
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
