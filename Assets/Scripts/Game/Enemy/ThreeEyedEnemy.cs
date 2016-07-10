using UnityEngine;
using System.Collections;

public class ThreeEyedEnemy : EnemyScript {
	private int count;
	private int hp;

	void Start () {
        EnemyIO.getInstance.GetEnemyData(EnemyType.ThreeEyedEnemy, out enemyInfo);
		hp = enemyInfo.hp;
    }

	void OnEnable(){
		hp = enemyInfo.hp;
	}

	// Update is called once per frame
	void Update () {
		if (hp > 0){ // no hit
			count++;
			if (count < 10){
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
		} else if(hp <= 0) {
			Die ();
		}

	}
}
