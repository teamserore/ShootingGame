using UnityEngine;
using System.Collections;

public class ThreeEyedEnemy : EnemyScript {
	private int count;
    
	void Start () {
        EnemyIO.getInstance.GetEnemyData(EnemyType.ThreeEyedEnemy, out enemyInfo);
    }
	
	// Update is called once per frame
	void Update () {
		if (enemyInfo.hp > 0){ // no hit
			count++;
			if (count < 30){
				transform.Translate (Vector2.down * Time.deltaTime * enemyInfo.speed); // move down
			}
			else if (count == 30){
				MonsterBulletManager.instance.CreateRightAngleBullet (gameObject);
			}
			else if (count == 40){
				MonsterBulletManager.instance.CreateRightAngleBullet (gameObject);
			}
			else if (count == 50){
				MonsterBulletManager.instance.CreateRightAngleBullet (gameObject);
			}
			else if (count > 100)
			{
				transform.Translate(Vector2.down * Time.deltaTime * enemyInfo.speed); // move down
				if (count == 110){
					MonsterBulletManager.instance.CreateRightAngleBullet (gameObject);
				} else if (count == 140){
					MonsterBulletManager.instance.CreateRightAngleBullet (gameObject);
				} else if (count == 170){
					MonsterBulletManager.instance.CreateRightAngleBullet (gameObject);
				} else if (count == 210){
					MonsterBulletManager.instance.CreateRightAngleBullet (gameObject);
				}
			}

			if (transform.position.y <= -10)
			{
				Die();
			}
		} else if(enemyInfo.hp <= 0) {
			Die ();
		}

	}
}
