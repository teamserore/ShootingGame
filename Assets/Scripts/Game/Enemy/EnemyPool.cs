using UnityEngine;
using System.Collections;

public class EnemyPool : MonoBehaviour {

	public GameObject[] typeEnemy = new GameObject[9];
	public GameObject[,] enemyObject;
	const int TYPE_COUNT = 9;
	const int ENEMY_COUNT = 10;
	GameObject go;

	//리스트를 동적으로 생성
	public void Create () {
		Dispose();
		enemyObject = new GameObject[TYPE_COUNT,ENEMY_COUNT];
	}

	public void AddEnemy () {
		for( int i=0; i<TYPE_COUNT; i++){
			for( int j=0; j<ENEMY_COUNT; j++){
				go = Instantiate(typeEnemy[i]);
				go.SetActive(false);
				enemyObject[i,j] = go;
			}
		}
	}

	//위의 함수를 이용하여 초기화된 객체들 중 특정 객체의 위치를 지정하고 활성화
	public GameObject NewEnemy(int type, int respawn, int itemType){
		if (enemyObject == null){
			return null;
		}

		for (int i = 0; i < ENEMY_COUNT; i++){
			GameObject mGameObject = (GameObject)enemyObject[type,i];
			if (mGameObject.activeSelf == false){
				switch (respawn) {
				// Top
				case 1:
					mGameObject.transform.position = new Vector2(-2f, 10f);
					break;
				case 2:
					mGameObject.transform.position = new Vector2(0f, 10f);
					break;
				case 3:
					mGameObject.transform.position = new Vector2(2f, 10f);
					break;
				case 4:
					mGameObject.transform.position = new Vector2(4f, 10f);
					break;
					// Left
				case 5:
					mGameObject.transform.position = new Vector2(-5f, 8f);
					break;
				case 6:
					mGameObject.transform.position = new Vector2(-5f, 7f);
					break;
				case 7:
					mGameObject.transform.position = new Vector2(-5f, 6f);
					break;
				case 8:
					mGameObject.transform.position = new Vector2(-5f, 5f);
					break;
					// Right
				case 9:
					mGameObject.transform.position = new Vector2(5f, 8f);
					break;
				case 10:
					mGameObject.transform.position = new Vector2(5f, 7f);
					break;
				case 11:
					mGameObject.transform.position = new Vector2(5f, 6f);
					break;
				case 12:
					mGameObject.transform.position = new Vector2(5f, 5f);
					break;
				}

                switch (itemType) {
                    case 0:
                        mGameObject.GetComponent<EnemyScript>().itemType = ItemType.POWER;
                        mGameObject.GetComponent<EnemyScript>().hasItem = true;
                        break;
                    case 1:
                        mGameObject.GetComponent<EnemyScript>().itemType = ItemType.BOMB;
                        mGameObject.GetComponent<EnemyScript>().hasItem = true;
                        break;
                    default:
                        mGameObject.GetComponent<EnemyScript>().hasItem = false;
                        break;
                }
				mGameObject.SetActive(true);

				return mGameObject;
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
				GameObject mGameObject = (GameObject)enemyObject[i,j];
				if (mGameObject == gameObject) {
					mGameObject.SetActive(false);
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
			GameObject mGameObject = enemyObject[type,i];
			if (mGameObject != null){
				mGameObject.SetActive(false);
			}
		}
	}

	public void Dispose () {
		if (enemyObject == null){
			return;
		}

		for (int i = 0; i < TYPE_COUNT; i++) {
			for (int j = 0; j < ENEMY_COUNT; j++) {
				GameObject mGameObject = enemyObject[i,j];
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
			GameObject mGameObject = enemyObject[type, i];
			if (mGameObject.activeSelf) 
			{
				yield return mGameObject.gameObject;
			}
		}
	}
}
