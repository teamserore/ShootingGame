using UnityEngine;
using System.Collections;

public class ItemPool : MonoBehaviour {

    public GameObject[] typeItem = new GameObject[3];
    public GameObject[,] itemObject;
    const int TYPE_COUNT = 3;
    const int ITEM_COUNT = 3;
    GameObject go;
    
    public void Create() {
        Dispose();
        itemObject = new GameObject[TYPE_COUNT, ITEM_COUNT];
    }

    public void AddItem () {
        for (int i = 0; i < TYPE_COUNT; i++) {
            for (int j = 0; j < ITEM_COUNT; j++) {
                go = Instantiate(typeItem[i]);
                go.SetActive(false);
                itemObject[i, j] = go;
            }
        }
    }

    public GameObject NewItem (ItemType itemType, GameObject respawn) {
        int type = (int)itemType;
        if (itemObject == null) {
            return null;
        }

        for (int i = 0; i < ITEM_COUNT; i++) {
            GameObject mGameObject = (GameObject)itemObject[type, i];
            if (mGameObject.activeSelf == false) {

                mGameObject.transform.position = respawn.transform.position;
                mGameObject.SetActive(true);

                return mGameObject;
            }
        }
        return null;
    }

    public void RemoveItemList(GameObject gameObject) {
        if (itemObject == null || gameObject == null) {
            return;
        }

        for (int i = 0; i < TYPE_COUNT; i++) {
            for (int j = 0; j < ITEM_COUNT; j++) {
                GameObject mGameObject = (GameObject)itemObject[i, j];
                if (mGameObject == gameObject) {
                    mGameObject.SetActive(false);
                    break;
                }
            }
        }
    }

    public void ClearItem(int type) {
        if (itemObject == null) {
            return;
        }

        for (int i = 0; i < ITEM_COUNT; i++) {
            GameObject mGameObject = itemObject[type, i];
            if (mGameObject != null) {
                mGameObject.SetActive(false);
            }
        }
    }

    public void Dispose() {
        if (itemObject == null) {
            return;
        }

        for (int i = 0; i < TYPE_COUNT; i++) {
            for (int j = 0; j < ITEM_COUNT; j++) {
                GameObject mGameObject = itemObject[i, j];
                GameObject.Destroy(mGameObject.gameObject);
            }
        }
        itemObject = null;
    }

    public IEnumerator GetEnumerator(int type)
    {
        if (itemObject == null) {
            yield break;
        }

        for (int i = 0; i < ITEM_COUNT; i++) {
            GameObject mGameObject = itemObject[type, i];
            if (mGameObject.activeSelf) {
                yield return mGameObject.gameObject;
            }
        }
    }
}

