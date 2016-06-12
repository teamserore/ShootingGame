using UnityEngine;
using System.Collections;

public class DevilEnemy : EnemyScript {
	/*public enum AttackStyle
	{
		BackMove,
		CrossMove
	}
	*/

	private int count;
	Vector2 relativePos;
	float angle;
	float EnemyAngle;
	float fX;
	float fY;
	//private AttackStyle attackStyle;
    
	void Start () {
        EnemyIO.getInstance.GetEnemyData(EnemyType.DevilEnemy, out enemyInfo);
		player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
		/*
		int attackRandom = Random.Range(0, 1);

		attackStyle = AttackStyle.BackMove; // 기본 값

		if (attackRandom == 0)
		{
			attackStyle = AttackStyle.BackMove;
		}
		else if (attackRandom == 1)
		{
			attackStyle = AttackStyle.CrossMove;
		}
		*/
    }
	
	// Update is called once per frame
	void Update () {
		if (enemyInfo.hp > 0){ // no hit
			count++;
			if (count < 40) {
				Vector2 direction = Vector2.right;
				if (this.transform.position.x > 5) {
					direction = Vector2.right;
				}
				if (this.transform.position.x < -5) {
					direction = Vector2.left;
				}
				transform.Translate (direction * Time.deltaTime * enemyInfo.speed); // move down
				if (count == 10) {
					MonsterBulletManager.instance.CreateDirectionBullet (gameObject);
				} else if (count == 15) {
					MonsterBulletManager.instance.CreateDirectionBullet (gameObject);
				} else if (count == 20) {
					MonsterBulletManager.instance.CreateDirectionBullet (gameObject);
				} else if (count == 5) {
					MonsterBulletManager.instance.CreateDirectionBullet (gameObject);
				}
			} else if (count < 50) {
				transform.Translate (Vector2.up * Time.deltaTime * enemyInfo.speed); // move down
			} else if (count == 70) {
				relativePos = player.transform.position - this.transform.position;
				angle = Mathf.Atan2 (relativePos.y, relativePos.x) * Mathf.Rad2Deg;

				fX = Mathf.Cos (angle) - Mathf.Sin (angle);
				fY = Mathf.Cos (angle) + Mathf.Sin (angle);

				EnemyAngle = Random.Range (60, 120);  
			} else if (count > 70) {
				transform.Translate (new Vector2 (-fX, fY) * 9 * Time.deltaTime);
			}
			if (transform.position.y <= -10){
				Destroy(this.gameObject);
			}
		}

		if (enemyInfo.hp <= 0){ // hit
			Die();
		}
	}
}
