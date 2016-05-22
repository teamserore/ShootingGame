using UnityEngine;
using System.Collections;

public class EliteEnemy : EnemyScript {
	private int enemyCode = 1;

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
			transform.Translate (Vector2.down * Time.deltaTime * enemyInfo.speed); // move down
			if (transform.position.y <= -10) {
				Die ();
			}
		}
	}
}
