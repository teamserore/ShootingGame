using UnityEngine;
using System.Collections;

public class MonsterBulletPool : MonoBehaviour {

	public GameObject[] typeMBullet = new GameObject[3];
	public GameObject[,] mbulletObject;
	const int TYPE_COUNT = 3;
	const int MBULLET_COUNT = 10;
	GameObject go;

	public void Create() {
		Dispose();
		mbulletObject = new GameObject[TYPE_COUNT, MBULLET_COUNT];
	}

	public void AddMBullet () {
		for (int i = 0; i < TYPE_COUNT; i++) {
			for (int j = 0; j < MBULLET_COUNT; j++) {
				go = Instantiate(typeMBullet[i]);
				go.SetActive(false);
				mbulletObject[i, j] = go;
			}
		}
	}

	public GameObject NewMBullet (MBulletType mbulletType, GameObject respawn) {
		int type = (int)mbulletType;
		if (mbulletObject == null) {
			return null;
		}

		for (int i = 0; i < MBULLET_COUNT; i++) {
			GameObject mGameObject = (GameObject)mbulletObject[type, i];
			if (mGameObject.activeSelf == false) {
				mGameObject.transform.position = respawn.transform.position;
				mGameObject.SetActive(true);

				return mGameObject;
			}
		}
		return null;
	}

	public void RemoveMBulletList (GameObject gameObject) {
		if (mbulletObject == null || gameObject == null) {
			return;
		}

		for (int i = 0; i < TYPE_COUNT; i++) {
			for (int j = 0; j < MBULLET_COUNT; j++) {
				GameObject mGameObject = (GameObject)mbulletObject[i, j];
				if (mGameObject == gameObject) {
					mGameObject.gameObject.SetActive(false);
					break;
				}
			}
		}
	}

	public void ClearMBullet (int type) {
		if (mbulletObject == null) {
			return;
		}

		for (int i = 0; i < MBULLET_COUNT; i++) {
			GameObject mGameObject = mbulletObject[type, i];
			if (mGameObject != null && mGameObject.active) {
				mGameObject.active = false;
				mGameObject.gameObject.SetActive(false);
			}
		}
	}

	public void Dispose() {
		if (mbulletObject == null) {
			return;
		}

		for (int i = 0; i < TYPE_COUNT; i++) {
			for (int j = 0; j < MBULLET_COUNT; j++) {
				GameObject mGameObject = mbulletObject [i, j];
				GameObject.Destroy (mGameObject.gameObject);
			}
		}
		mbulletObject = null;
	}

	public IEnumerator GetEnumerator(int type)
	{
		if (mbulletObject == null) {
			yield break;
		}

		for (int i = 0; i < MBULLET_COUNT; i++) {
			GameObject mGameObject = mbulletObject[type, i];
			if (mGameObject.activeSelf) {
				yield return mGameObject.gameObject;
			}
		}
	}
}