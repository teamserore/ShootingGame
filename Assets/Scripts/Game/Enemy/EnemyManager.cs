using UnityEngine;
using System.Collections;

public class EnemyManager :MonoBehaviour {
	EnemyPool enemyPool;
	WaveStruct waveInfo;
	UIManager uiManager;

	void Start() {
		waveInfo.index = 0;
		waveInfo.delayTime = 1;
		waveInfo.enemyType = 0;
		waveInfo.respawnType = 1;
    }

	void Update(){
		if (waveInfo.enemyType == 0) {
			//enemyPool.AddEnemy (StarEnemy);
		}
	}
}