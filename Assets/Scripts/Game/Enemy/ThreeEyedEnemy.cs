using UnityEngine;
using System.Collections;

public class ThreeEyedEnemy : EnemyScript {
    
	void Start () {
        EnemyIO.getInstance.GetEnemyData(EnemyType.ThreeEyedEnemy, out enemyInfo);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
