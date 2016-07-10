using UnityEngine;
using System.Collections;

public class PirateEnemy : EnemyScript {
	private int count = 0;
	private int hp;

    void Start() {
        EnemyIO.getInstance.GetEnemyData(EnemyType.PirateEnemy, out enemyInfo);
		hp = enemyInfo.hp;
    }

	void OnEnable(){
		hp = enemyInfo.hp;
	}

	// Update is called once per frame
	void Update (){
		count++;
		if (count < 30) {
			transform.Translate (Vector2.down * Time.deltaTime * enemyInfo.speed); // move down
		} else if (count == 30) {
			MonsterBulletManager.instance.CreateAimedBullet (gameObject);
		} else if (count == 40) {
			MonsterBulletManager.instance.CreateAimedBullet (gameObject);
		} else if (count > 100) {
			transform.Translate (Vector2.down * Time.deltaTime * enemyInfo.speed); // move down
		}
		if (hp <= 0) {
			Die ();
		} else if (transform.position.y <= -10) {
			Die ();
		}
	}
}
