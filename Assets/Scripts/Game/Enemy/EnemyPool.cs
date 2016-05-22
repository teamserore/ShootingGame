using UnityEngine;
using System.Collections;

public class EnemyPool : MonoBehaviour {
	MGameObject[,] enemyObject;
	const int TYPE_COUNT = 7;
	const int ENEMY_COUNT = 10;

	class MGameObject
	{
		public bool active;
		public GameObject gameObject;
	}
		
	//리스트를 동적으로 생성
	public void Create () 
	{
		Dispose();
		enemyObject = new MGameObject[TYPE_COUNT,ENEMY_COUNT];
	}

	public void AddEnemy (Object original) 
	{
		for( int i=0; i<TYPE_COUNT; i++)
		{
			for( int j=0; j<ENEMY_COUNT; j++)
			{
				MGameObject mGameObject = new MGameObject();
				mGameObject.active = false;
				mGameObject.gameObject = GameObject.Instantiate(original) as GameObject;
				mGameObject.gameObject.SetActive(false);
				switch (i)
				{
				case 1 :
					mGameObject.gameObject.AddComponent<StarEnemy>();
					break;
				case 2 :
					mGameObject.gameObject.AddComponent<EliteEnemy>();
					break;
				case 3 :
					mGameObject.gameObject.AddComponent<OneEyedEnemy>();
					break;
				case 4 :
					mGameObject.gameObject.AddComponent<PirateEnemy>();
					break;
				case 5 :
					mGameObject.gameObject.AddComponent<ThreeEyedEnemy>();
					break;
				case 6 :
					mGameObject.gameObject.AddComponent<DevilEnemy>();
					break;
				case 7 :
					mGameObject.gameObject.AddComponent<KniefEnemy>();
					break;
				}
				enemyObject[i,j] = mGameObject;
			}
		}

	}

	//위의 함수를 이용하여 초기화된 객체들 중 특정 객체의 위치를 지정하고 활성화
	public GameObject NewEnemy(int type, GameObject respawn)
	{
		if (enemyObject == null)
		{
			return null;
		}

		for (int i = 0; i < ENEMY_COUNT; i++)
		{
			MGameObject mGameObject = (MGameObject)enemyObject[type,i];

			if (mGameObject.active == false)
			{
				mGameObject.gameObject.transform.position = respawn.transform.position;
				mGameObject.gameObject.transform.rotation = respawn.transform.rotation;

				mGameObject.active = true;
				mGameObject.gameObject.SetActive(true);

				return mGameObject.gameObject;
			}
		}
		return null;
	}

	public void RemoveEnemytList (int type, int index) 
	{
		if (enemyObject == null || gameObject == null)
		{
			return;
		}


		for (int i = 0; i < ENEMY_COUNT; i++)
		{
			MGameObject mGameObject = (MGameObject)enemyObject[type,i];

			if (mGameObject.gameObject == gameObject)
			{
				mGameObject.active = false;
				mGameObject.gameObject.SetActive(false);

				break;
			}
		}
	} 

	public void ClearEnemy (int type) 
	{
		if (enemyObject == null)
		{
			return;
		}

		for (int i = 0; i < ENEMY_COUNT; i++)
		{
			MGameObject mGameObject = (MGameObject)enemyObject[type,i];

			if (mGameObject != null && mGameObject.active)
			{
				mGameObject.active = false;
				mGameObject.gameObject.SetActive(false);
			}
		}
	}

	public void Dispose () 
	{
		if (enemyObject == null)
		{
			return;
		}

		for (int i = 0; i < TYPE_COUNT; i++)
		{
			for (int j = 0; j < ENEMY_COUNT; j++)
			{
				MGameObject mGameObject = (MGameObject)enemyObject[i,j];
				GameObject.Destroy(mGameObject.gameObject);
			}

		}

		enemyObject = null;
	}

	public IEnumerator GetEnumerator(int type)
	{
		if (enemyObject == null)
		{
			yield break;
		}

		for (int i = 0; i < ENEMY_COUNT; i++)
		{
			MGameObject mGameObject = (MGameObject)enemyObject[type, i];

			if (mGameObject.active)
			{
				yield return mGameObject.gameObject;
			}
		}
	}
}
