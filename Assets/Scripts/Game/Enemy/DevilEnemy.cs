using UnityEngine;
using System.Collections;

public class DevilEnemy : EnemyScript {
	public enum AttackStyle
	{
		BackMove,
		CrossMove
	}
		
	private int count;
	private AttackStyle attackStyle;
    
	void Start () {
        EnemyIO.getInstance.GetEnemyData(EnemyType.DevilEnemy, out enemyInfo);
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
    }
	
	// Update is called once per frame
	void Update () {
		if (enemyInfo.hp > 0){ // no hit
			count++;
			if (count < 40){
				Vector2 direction = Vector2.right;
				if (this.transform.position.x > 5)
				{
					direction = Vector2.right;
				}
				if (this.transform.position.x < -5)
				{
					direction = Vector2.left;
				}
				transform.Translate(direction * Time.deltaTime * enemyInfo.speed); // move down
			}
			else if (count == 40){
				//Instantiate(enemyBullet, this.transform.position, Quaternion.identity);
			}
			else if (count == 45){
				//Instantiate(enemyBullet, this.transform.position, Quaternion.identity);
			}
			else if (count == 50){
				//Instantiate(enemyBullet, this.transform.position, Quaternion.identity);
			}
			else if (count == 55){
				//Instantiate(enemyBullet, this.transform.position, Quaternion.identity);
			}
			else if (count > 100){
				if (attackStyle == AttackStyle.CrossMove){
					Vector2 direction = Vector2.left;
					if (this.transform.position.x > 0){
						direction += Vector2.left;
						direction += Vector2.down;
						direction.Normalize();
						transform.Translate(direction * Time.deltaTime * enemyInfo.speed); // move down
					}
					else if (this.transform.position.x < 0){
						direction += Vector2.right;
						direction += Vector2.down;
						direction.Normalize();
						transform.Translate(direction * Time.deltaTime * enemyInfo.speed); // move down
					}
				}
				else if (attackStyle == AttackStyle.BackMove){
					transform.Translate(Vector2.up * Time.deltaTime * enemyInfo.speed); // move down
				}
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
