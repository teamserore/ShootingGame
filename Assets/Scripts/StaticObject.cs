using UnityEngine;
using System.Collections;

// DATA IO가 완료될 시점까지 사용되는 클래스
public class StaticObject :MonoBehaviour {
    public static StaticObject mInstance;

    /** InGame에 필요한 정보 **/

	//Enemy
	public static ArrayList enemyList = new ArrayList();
	public static ArrayList waveList = new ArrayList();

    // bullet
    public static float bulletSpeed = 9f; // speed of player laser
    public static int bulletPower = 1; // power of player laser

    // aimed bullet (bullet for no.2 and no.3)
    public static int aimedPower = 1; // power of aimed bullet

    public static StaticObject instance {
        get {
            if (mInstance == null) {
                mInstance = FindObjectOfType<StaticObject>();
            }
            return mInstance;
        }
    }

	public void Start() {
		MakeEnemy();
		MakeWave();
	}
		
	public void MakeEnemy(){
		EnemyStruct enemyStruct0 = new EnemyStruct();
		enemyStruct0.index = 0;
		enemyStruct0.power = 2;
		enemyStruct0.hp = 3;
		enemyStruct0.speed = 4;
		enemyStruct0.dropCandy = 1;
		enemyList.Add (enemyStruct0);

		EnemyStruct enemyStruct1 = new EnemyStruct();
		enemyStruct1.index = 1;
		enemyStruct1.power = 2;
		enemyStruct1.hp = 3;
		enemyStruct1.speed = 4;
		enemyStruct1.dropCandy = 1;
		enemyList.Add (enemyStruct1);

		EnemyStruct enemyStruct2 = new EnemyStruct();
		enemyStruct2.index = 2;
		enemyStruct2.power = 2;
		enemyStruct2.hp = 3;
		enemyStruct2.speed = 4;
		enemyStruct2.dropCandy = 1;
		enemyList.Add (enemyStruct2);

		EnemyStruct enemyStruct3 = new EnemyStruct();
		enemyStruct3.index = 3;
		enemyStruct3.power = 2;
		enemyStruct3.hp = 3;
		enemyStruct3.speed = 4;
		enemyStruct3.dropCandy = 1;
		enemyList.Add (enemyStruct3);

		EnemyStruct enemyStruct4 = new EnemyStruct();
		enemyStruct4.index = 4;
		enemyStruct4.power = 2;
		enemyStruct4.hp = 3;
		enemyStruct4.speed = 4;
		enemyStruct4.dropCandy = 1;
		enemyList.Add (enemyStruct4);

		EnemyStruct enemyStruct5 = new EnemyStruct();
		enemyStruct5.index = 5;
		enemyStruct5.power = 2;
		enemyStruct5.hp = 3;
		enemyStruct5.speed = 4;
		enemyStruct5.dropCandy = 1;
		enemyList.Add (enemyStruct5);

		EnemyStruct enemyStruct6 = new EnemyStruct();
		enemyStruct6.index = 6;
		enemyStruct6.power = 2;
		enemyStruct6.hp = 3;
		enemyStruct6.speed = 4;
		enemyStruct6.dropCandy = 1;
		enemyList.Add (enemyStruct6);

	}

	private void MakeWave() {
		// Wave 정보 초기화시키기.
		WaveStruct wave1 = new WaveStruct();
		wave1.index = 0;
		wave1.delayTime = 0;
		wave1.enemyType = 2;
		wave1.respawnType = 1;
		wave1.hp = 10;
		wave1.score = 10;
		wave1.candy = 10;
		wave1.itemType = -1;
		waveList.Add(wave1);

		WaveStruct wave2 = new WaveStruct();
		wave2.index = 1;
		wave2.delayTime = 1;
		wave2.enemyType = 0;
		wave2.respawnType = 4;
		wave2.hp = 10;
		wave2.score = 0;
		wave2.candy = 10;
		wave2.itemType = -1;
		waveList.Add(wave2);

		WaveStruct wave3 = new WaveStruct();
		wave3.index = 2;
		wave3.delayTime = 1;
		wave3.enemyType = 1;
		wave3.respawnType = 2;
		wave3.hp = 10;
		wave3.score = 0;
		wave3.candy = 10;
		wave3.itemType = 1;
		waveList.Add(wave3);

		WaveStruct wave4 = new WaveStruct();
		wave4.index = 3;
		wave4.delayTime = 2;
		wave4.enemyType = 3;
		wave4.respawnType = 3;
		wave4.hp = 10;
		wave4.score = 0;
		wave4.candy = 10;
		wave4.itemType = -1;
		waveList.Add(wave4);

		WaveStruct wave5 = new WaveStruct();
		wave5.index = 4;
		wave5.delayTime = 2;
		wave5.enemyType = 3;
		wave5.respawnType = 3;
		wave5.hp = 10;
		wave5.score = 0;
		wave5.candy = 10;
		wave5.itemType = 0;
		waveList.Add(wave5);
	}
}
