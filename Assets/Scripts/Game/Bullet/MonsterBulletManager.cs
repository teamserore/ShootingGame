using UnityEngine;
using System.Collections;

public enum MBulletType {
	AIMED,
	DIRECTION,
	RIGHTANGLE
}

public class MonsterBulletManager : MonoBehaviour {
	ArrayList bulletList;
	public MonsterBulletPool mbulletPool;
	public UIManager uiManager;
	PlayerScript player;

	private static MonsterBulletManager _instance;

	public static MonsterBulletManager instance {
		get {
			return _instance;
		}
		set {
			value = _instance;
		}
	}

	void Start() {
		mbulletPool.Create();
		mbulletPool.AddMBullet();
	}

	void Awake() {
		_instance = this;
	}
		
	public GameObject CreateMBullet(MBulletType mbullettype, GameObject respawn) {
		return mbulletPool.NewMBullet(mbullettype, respawn);
	}
		
	public void DieMBullet(GameObject gameObject) {
		mbulletPool.RemoveMBulletList(gameObject);
	}
}
