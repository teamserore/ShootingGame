using UnityEngine;
using System.Collections;

public enum BulletType{
	AIMED,
	DIRECTION,
	PLAYER
}

public class MonsterBulletPool : MonoBehaviour {
	MGameObject[,] bulletObject;
	const int TYPE_COUNT = 3;
	const int BULLET_COUNT = 10;

	class MGameObject{
		public bool active;
		public GameObject gameObject;
	}

	//리스트를 동적으로 생성
	public void Create () {
		Dispose();
		bulletObject = new MGameObject[TYPE_COUNT,BULLET_COUNT];
	}

	public void AddBullet (Object original) {
		for( int i=0; i<TYPE_COUNT; i++){
			for( int j=0; j<BULLET_COUNT; j++){
				MGameObject mGameObject = new MGameObject();
				mGameObject.active = false;
				mGameObject.gameObject = GameObject.Instantiate(original) as GameObject;
				mGameObject.gameObject.SetActive(false);
				switch (i){
				case (int)BulletType.AIMED:
					mGameObject.gameObject.AddComponent<AimedBullet>();
					break;
				case (int)BulletType.DIRECTION:
					mGameObject.gameObject.AddComponent<DirectionBullet>();
					break;
				}
				bulletObject[i,j] = mGameObject;
			}
		}

	}

	//위의 함수를 이용하여 초기화된 객체들 중 특정 객체의 위치를 지정하고 활성화
	public GameObject NewBullet(int type, GameObject respawn){
		if (bulletObject == null){
			return null;
		}

		for (int i = 0; i < BULLET_COUNT; i++){
			MGameObject mGameObject = (MGameObject)bulletObject[type,i];

			if (mGameObject.active == false){
				mGameObject.gameObject.transform.position = respawn.transform.position;
				mGameObject.gameObject.transform.rotation = respawn.transform.rotation;

				mGameObject.active = true;
				mGameObject.gameObject.SetActive(true);

				return mGameObject.gameObject;
			}
		}
		return null;
	}

	public void RemoveBullettList (int type, int index) {
		if (bulletObject == null || gameObject == null)
		{
			return;
		}


		for (int i = 0; i < BULLET_COUNT; i++){
			MGameObject mGameObject = (MGameObject)bulletObject[type,i];

			if (mGameObject.gameObject == gameObject)
			{
				mGameObject.active = false;
				mGameObject.gameObject.SetActive(false);

				break;
			}
		}
	} 

	public void ClearBullet (int type) {
		if (bulletObject == null){
			return;
		}

		for (int i = 0; i < BULLET_COUNT; i++){
			MGameObject mGameObject = (MGameObject)bulletObject[type,i];

			if (mGameObject != null && mGameObject.active){
				mGameObject.active = false;
				mGameObject.gameObject.SetActive(false);
			}
		}
	}

	public void Dispose () {
		if (bulletObject == null){
			return;
		}

		for (int i = 0; i < TYPE_COUNT; i++){
			for (int j = 0; j < BULLET_COUNT; j++){
				MGameObject mGameObject = (MGameObject)bulletObject[i,j];
				GameObject.Destroy(mGameObject.gameObject);
			}

		}

		bulletObject = null;
	}

	public IEnumerator GetEnumerator(int type){
		if (bulletObject == null){
			yield break;
		}

		for (int i = 0; i < BULLET_COUNT; i++){
			MGameObject mGameObject = (MGameObject)bulletObject[type, i];

			if (mGameObject.active){
				yield return mGameObject.gameObject;
			}
		}
	}
}
