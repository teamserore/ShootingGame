using UnityEngine;
using System.Collections;

public class PirateEnemy : EnemyScript {
	private int enemyCode = 3;
	private int count = 0;

	// Use this for initialization
	void Start () 
	{
		//
	}

	void Awake ()
	{
        enemyInfo = new EnemyStruct();
        enemyInfo = (EnemyStruct)StaticObject.enemyList[enemyCode];
    }

	// Update is called once per frame
	void Update () 
	{
		if (enemyInfo.hp <= 0) 
		{
			Die ();
		}
		else
		{
			count++;
			if (count < 40) {
				transform.Translate (Vector2.down * Time.deltaTime * enemyInfo.speed); // move down
			} else if (count == 40) {
				//Instantiate (enemyBullet, this.transform.position, Quaternion.identity);
			} else if (count == 50) {
				//Instantiate (enemyBullet, this.transform.position, Quaternion.identity);
			} else if (count > 100){
				transform.Translate (Vector2.down * Time.deltaTime * enemyInfo.speed); // move down
			}

			if (transform.position.y <= -10){
				Die ();
			}
		}
	}
}
