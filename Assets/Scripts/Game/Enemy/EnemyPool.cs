using UnityEngine;
using System.Collections;

public class EnemyPool : MonoBehaviour {

    private static EnemyPool _instance;
    public static EnemyPool instance {
        get {
            return _instance;
        }
        set {
            value = _instance;
        }
    }

    MGameObject[,] enemyObject;
	const int TYPE_COUNT = 7;
	const int ENEMY_COUNT = 10;

	class MGameObject {
		public bool active;
		public GameObject gameObject;
	}
		
	//리스트를 동적으로 생성
	public void Create () {
		Dispose();
		enemyObject = new MGameObject[TYPE_COUNT,ENEMY_COUNT];
	}

	public void AddEnemy () {
		for( int i=0; i<TYPE_COUNT; i++){
			for( int j=0; j<ENEMY_COUNT; j++){
				MGameObject mGameObject = new MGameObject();
				mGameObject.active = false;
                switch (i){
				    case 0 :
                        mGameObject.gameObject = (GameObject)Resources.Load("Prefabs/StarBalloon") as GameObject;
                        break;
				    case 1 :
                        mGameObject.gameObject = (GameObject)Resources.Load("Prefabs/EliteBalloon") as GameObject;
					    break;
				    case 2 :
                        mGameObject.gameObject = (GameObject)Resources.Load("Prefabs/OneEyedBalloon") as GameObject;
					    break;
				    case 3 :
                        mGameObject.gameObject = (GameObject)Resources.Load("Prefabs/PirateBalloon") as GameObject;
					    break;
				    case 4 :
                        mGameObject.gameObject = (GameObject)Resources.Load("Prefabs/ThreeEyedBalloon") as GameObject;
					    break;
				    case 5 :
                        mGameObject.gameObject = (GameObject)Resources.Load("Prefabs/DevilBalloon") as GameObject;
					    break;
				    case 6 :
                        mGameObject.gameObject = (GameObject)Resources.Load("Prefabs/KniefBalloon") as GameObject;
					    break;
				}
                mGameObject.gameObject.SetActive(false);
                enemyObject[i,j] = mGameObject;
			}
		}
	}

	//위의 함수를 이용하여 초기화된 객체들 중 특정 객체의 위치를 지정하고 활성화
	public GameObject NewEnemy(int type, int respawn){
		if (enemyObject == null){
			return null;
		}

		for (int i = 0; i < ENEMY_COUNT; i++){
			MGameObject mGameObject = (MGameObject)enemyObject[type,i];

			if (mGameObject.active == false){
                switch (respawn) {
                    // Top
                    case 0:
                        mGameObject.gameObject.transform.position = new Vector2(-2f, 10f);
                        break;
                    case 1:
                        mGameObject.gameObject.transform.position = new Vector2(0f, 10f);
                        break;
                    case 2:
                        mGameObject.gameObject.transform.position = new Vector2(2f, 10f);
                        break;
                    case 3:
                        mGameObject.gameObject.transform.position = new Vector2(4f, 10f);
                        break;
                    // Left
                    case 4:
                        mGameObject.gameObject.transform.position = new Vector2(-5f, 8f);
                        break;
                    case 5:
                        mGameObject.gameObject.transform.position = new Vector2(-5f, 7f);
                        break;
                    case 6:
                        mGameObject.gameObject.transform.position = new Vector2(-5f, 6f);
                        break;
                    case 7:
                        mGameObject.gameObject.transform.position = new Vector2(-5f, 5f);
                        break;
                    // Right
                    case 8:
                        mGameObject.gameObject.transform.position = new Vector2(5f, 8f);
                        break;
                    case 9:
                        mGameObject.gameObject.transform.position = new Vector2(5f, 7f);
                        break;
                    case 10:
                        mGameObject.gameObject.transform.position = new Vector2(5f, 6f);
                        break;
                    case 11:
                        mGameObject.gameObject.transform.position = new Vector2(5f, 5f);
                        break;
                }
                
				mGameObject.active = true;
				mGameObject.gameObject.SetActive(true);

				return mGameObject.gameObject;
			}
		}
		return null;
	}

    public void RemoveEnemytList (GameObject gameObject) {
		if (enemyObject == null || gameObject == null){
			return;
		}

        for (int i = 0; i < TYPE_COUNT; i++) {
            for (int j = 0; j < ENEMY_COUNT; j++) {
                MGameObject mGameObject = (MGameObject)enemyObject[i, j];

                if (mGameObject.gameObject == gameObject) {
                    mGameObject.active = false;
                    mGameObject.gameObject.SetActive(false);

                    break;
                }
            }
        }
	} 

	public void ClearEnemy (int type) {
		if (enemyObject == null){
			return;
		}

		for (int i = 0; i < ENEMY_COUNT; i++){
			MGameObject mGameObject = (MGameObject)enemyObject[type,i];

			if (mGameObject != null && mGameObject.active){
				mGameObject.active = false;
				mGameObject.gameObject.SetActive(false);
			}
		}
	}

	public void Dispose () {
		if (enemyObject == null){
			return;
		}

		for (int i = 0; i < TYPE_COUNT; i++) {
			for (int j = 0; j < ENEMY_COUNT; j++) {
				MGameObject mGameObject = (MGameObject)enemyObject[i,j];
				GameObject.Destroy(mGameObject.gameObject);
			}

		}

		enemyObject = null;
	}

	public IEnumerator GetEnumerator(int type) {
		if (enemyObject == null){
			yield break;
		}

		for (int i = 0; i < ENEMY_COUNT; i++){
			MGameObject mGameObject = (MGameObject)enemyObject[type, i];

			if (mGameObject.active){
				yield return mGameObject.gameObject;
			}
		}
	}
}
