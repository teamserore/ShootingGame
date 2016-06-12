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
		
	public GameObject CreateAimedBullet(GameObject respawn) {
		return mbulletPool.NewMBullet(MBulletType.AIMED, respawn);
	}

	public GameObject CreateDirectionBullet(GameObject respawn) {
		return mbulletPool.NewMBullet(MBulletType.DIRECTION, respawn);
	}

	public GameObject CreateRightAngleBullet(GameObject respawn) {
		return mbulletPool.NewMBullet(MBulletType.RIGHTANGLE, respawn);
	}

	public void DieMBullet(GameObject gameObject) {
		mbulletPool.RemoveMBulletList(gameObject);
	}
}
