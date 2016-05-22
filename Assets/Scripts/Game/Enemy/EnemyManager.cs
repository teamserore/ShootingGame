using UnityEngine;
using System.Collections;

public class EnemyManager :MonoBehaviour {
	EnemyPool enemyPool;
	UIManager uiManager;

	EnemyScript[] enemyList;
	int endPos = 0;

	void Start() {
    }

	public GameObject CreateEnemy(GameObject respawn) {
		int type = Random.Range(0, 2);
		return enemyPool.NewEnemy(type, respawn);
	}

	public void GetEnemy(Item item, GameObject gameObject) {
		uiManager.AddItemToSlot(item, endPos);
		//enemyList[endPos] = item;
		endPos++;

		gameObject.SetActive(false);
	}
}