using UnityEngine;
using System.Collections;

public class KniefEnemy : EnemyScript {
    
	void Start () {
        EnemyIO.getInstance.GetEnemyData(EnemyType.KniefEnemy, out enemyInfo);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
