using UnityEngine;
using System.Collections;

public class MonsterBulletManager : MonoBehaviour {
	ArrayList bulletList;
	public MonsterBulletPool mbulletPool;
	public UIManager uiManager;
	PlayerScript player;
	int index = 0;

	private static MonsterBulletManager _instance;

	public static MonsterBulletManager instance {
		get {
			return _instance;
		}
		set {
			value = _instance;
		}
	}
	void Awake() {
		_instance = this;
	}

	void Start() {
		mbulletPool.Create();
		mbulletPool.AddMBullet();
		StartCoroutine(MakeMBullet());
	}

	public GameObject CreateMBullet(MBulletType mbullettype, GameObject respawn) {
		return mbulletPool.NewMBullet(mbullettype, respawn);
	}
		
	public IEnumerator MakeMBullet() {
		WaveStruct waveInfo;
		WaveIO.getInstance.GetWaveData(index++, out waveInfo);
		//mbulletPool.NewMBullet(waveInfo.enemyType, waveInfo.respawnType);
		yield return new WaitForSeconds((float)waveInfo.delayTime);
		StartCoroutine(MakeMBullet());
	}

	public void DieMBullet(GameObject gameObject) {
		mbulletPool.RemoveMBulletList(gameObject);
	}
}
