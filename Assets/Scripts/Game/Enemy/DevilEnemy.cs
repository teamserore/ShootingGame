using UnityEngine;
using System.Collections;

public class DevilEnemy : EnemyScript {
	private int count;
	Vector2 relativePos;
	float EnemyAngle;
	float fX;
	float fY;
	protected BoxCollider2D coll = null;

	void Start () {
		EnemyIO.getInstance.GetEnemyData (EnemyType.DevilEnemy, out enemyInfo);
		player = GameObject.FindWithTag ("Player").GetComponent<PlayerScript> ();
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
				EnemyAngle = Mathf.Atan2 (relativePos.y, relativePos.x) * Mathf.Rad2Deg;

				fX = Mathf.Cos (EnemyAngle) - Mathf.Sin (EnemyAngle);
				fY = Mathf.Cos (EnemyAngle) + Mathf.Sin (EnemyAngle);
				// need to fix it

			} else if (count < 300) {
				transform.Translate (new Vector2(-fX , fY) * Time.deltaTime * enemyInfo.speed);
			}
			if (transform.position.y <= -10){
				Die ();
			}

		} else if (enemyInfo.hp <= 0) {
			Die ();
		}
	}
}