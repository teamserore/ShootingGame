using UnityEngine;
using System.Collections;

public enum EnemyType {
    StarEnemy,
    EleteEnemy,
    OneEyedEnemy,
    PirateEnemy,
    DevilEnemy,
    ThreeEyedEnemy,
    KniefEnemy
}

public class EnemyManager :MonoBehaviour {

    private static EnemyManager _instance;
    public static EnemyManager instance {
        get {
            return _instance;
        }
        set {
            value = _instance;
        }
    }
   
	public EnemyPool enemyPool;
	public UIManager uiManager;
    int index = 0;

	void Start() {
		enemyPool.Create();
		enemyPool.AddEnemy();
        StartCoroutine(makeEnemy());
    }

    public IEnumerator makeEnemy() {
        WaveStruct waveInfo;
        WaveIO.getInstance.GetWaveData(index++, out waveInfo);
        enemyPool.NewEnemy(waveInfo.enemyType, waveInfo.respawnType);
		yield return new WaitForSeconds((float)waveInfo.delayTime);
        StartCoroutine(makeEnemy());
    }

    public void DieEnemy(GameObject gameObject) {
        enemyPool.RemoveEnemytList(gameObject);
    }
}