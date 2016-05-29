using UnityEngine;
using System.Collections;

public class DevilEnemy : EnemyScript {
    
	void Start () {
        EnemyIO.getInstance.GetEnemyData(EnemyType.DevilEnemy, out enemyInfo);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
