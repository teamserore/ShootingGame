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
			if (count < 40)
			{
				transform.Translate (Vector2.down * Time.deltaTime * enemyInfo.speed); // move down
			}
			else if (count == 40)
			{
				//Instantiate(enemyBullet, this.transform.position, Quaternion.identity);
			}
			else if (count == 50)
			{
				//Instantiate(enemyBullet, this.transform.position, Quaternion.identity);
			}
			else if (count > 100)
			{
				transform.Translate(Vector2.down * Time.deltaTime * enemyInfo.speed); // move down
			}

			if (transform.position.y <= -10)
			{
				Destroy(this.gameObject);
			}

			//if (transform.position.y > 10)
			//{
			//    Destroy(this.gameObject);
			//}
		}
	}
}
