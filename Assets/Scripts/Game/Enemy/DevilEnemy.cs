using UnityEngine;
using System.Collections;

public class DevilEnemy : EnemyScript {
	private int count;
	Vector2 relativePos;
	float angle;
	float EnemyAngle;
	float fX;
	float fY;

	void Start () {
		EnemyIO.getInstance.GetEnemyData (EnemyType.DevilEnemy, out enemyInfo);
		player = GameObject.FindWithTag ("Player").GetComponent<PlayerScript> ();
	}

	// Update is called once per frame
	void Update () {
		count++;
		if (enemyInfo.hp > 0) {
			if (count < 10) {
				transform.Translate (Vector2.down * Time.deltaTime * enemyInfo.speed);
			} else if (count < 50) {
				if (this.transform.position.x <= 5) {
					transform.Translate (Vector2.right * Time.deltaTime * enemyInfo.speed); 
				}
				if (count == 30) {
					MonsterBulletManager.instance.CreateDirectionBullet (gameObject);
				}
			} else if (count < 90) {
				if (this.transform.position.x >= -5) {
					transform.Translate (Vector2.left * Time.deltaTime * enemyInfo.speed); 
				}
				if (count == 70) {
					MonsterBulletManager.instance.CreateDirectionBullet (gameObject);
				}
			} else if (count < 130) {
				if (this.transform.position.x <= 5) {
					transform.Translate (Vector2.right * Time.deltaTime * enemyInfo.speed); 
				}
				if (count == 110) {
					MonsterBulletManager.instance.CreateDirectionBullet (gameObject);
				}
			} else if (count < 170) {
				if (this.transform.position.x >= -5) {
					transform.Translate (Vector2.left * Time.deltaTime * enemyInfo.speed); 
				}
				if (count == 150) {
					MonsterBulletManager.instance.CreateDirectionBullet (gameObject);
				}
			} else if (count < 200) {
				if (this.transform.position.x <= 0) {
					transform.Translate (Vector2.right * Time.deltaTime * enemyInfo.speed); 
				}
			} else if (count < 220) {
				transform.Translate (Vector2.down * Time.deltaTime * enemyInfo.speed); // move down
			} else if (count == 220) {
				relativePos = player.transform.position - this.transform.position;
				angle = Mathf.Atan2 (relativePos.y, relativePos.x) * Mathf.Rad2Deg;

				transform.localRotation = Quaternion.Euler(0, 0, (angle - 90));

				//fX = Mathf.Cos (angle) - Mathf.Sin (angle);
				//fY = Mathf.Cos (angle) + Mathf.Sin (angle);

				EnemyAngle = Random.Range (60 , 120);  
			} else if (count < 300) {
				transform.Translate (transform.up * enemyInfo.speed * Time.deltaTime, Space.World );
			}
			if (transform.position.y <= -10){
				Die ();
			}

		} else if (enemyInfo.hp <= 0) {
			Die ();
		}
	}
}