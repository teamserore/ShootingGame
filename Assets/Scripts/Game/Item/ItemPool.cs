using UnityEngine;
using System.Collections;

public enum ItemType{
    POWER,
    LIFE,
    BOMB
}
public class ItemPool : MonoBehaviour {
    MGameObejct[,] itemObject;
    const int TYPE_COUNT = 3;
    const int ITEM_COUNT = 5;

    class MGameObejct
    {
        public bool active;
        public GameObject gameObject;
    }
    
    public void Create() {
        Dispose();
        itemObject = new MGameObejct[TYPE_COUNT, ITEM_COUNT];
    }

    public void AddItem (Object original) {
        for( int i=0; i<TYPE_COUNT; i++)
        {
            for( int j=0; j<ITEM_COUNT; j++)
            {
                MGameObejct mGameObject = new MGameObejct();
                mGameObject.active = false;
                mGameObject.gameObject = GameObject.Instantiate(original) as GameObject;
                mGameObject.gameObject.SetActive(false);
                switch (i)
                {
                    case (int)ItemType.POWER:
                        mGameObject.gameObject.AddComponent<ItemPower>();
                        break;
                    case (int)ItemType.LIFE:
                        mGameObject.gameObject.AddComponent<ItemLife>();
                        break;
                    case (int)ItemType.BOMB:
                        mGameObject.gameObject.AddComponent<ItemBomb>();
                        break;
                }
                itemObject[i,j] = mGameObject;
            }
        }
        
    }

    public GameObject NewItem (int type, GameObject respawn) {
        if (itemObject == null)
        {
            return null;
        }

        for (int i = 0; i < ITEM_COUNT; i++)
        {
            MGameObejct mGameObject = (MGameObejct)itemObject[type,i];

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

    public void RemoveItemList (int type, int index) {
        if (itemObject == null || gameObject == null)
        {
            return;
        }
        

        for (int i = 0; i < ITEM_COUNT; i++)
        {
            MGameObejct mGameObject = (MGameObejct)itemObject[type,i];

            if (mGameObject.gameObject == gameObject)
            {
                mGameObject.active = false;
                mGameObject.gameObject.SetActive(false);

                break;
            }
        }
    }

    public void ClearItem (int type) {
        if (itemObject == null)
        {
            return;
        }
        
        for (int i = 0; i < ITEM_COUNT; i++)
        {
            MGameObejct mGameObject = (MGameObejct)itemObject[type,i];

            if (mGameObject != null && mGameObject.active)
            {
                mGameObject.active = false;
                mGameObject.gameObject.SetActive(false);
            }
        }
    }

    public void Dispose() {
        if (itemObject == null)
        {
            return;
        }
        
        for (int i = 0; i < TYPE_COUNT; i++)
        {
            for (int j = 0; j < ITEM_COUNT; j++)
            {
                MGameObejct mGameObject = (MGameObejct)itemObject[i,j];
                GameObject.Destroy(mGameObject.gameObject);
            }

        }

        itemObject = null;
    }

    public IEnumerator GetEnumerator(int type)
    {
        if (itemObject == null)
        {
            yield break;
        }
        
        for (int i = 0; i < ITEM_COUNT; i++)
        {
            MGameObejct mGameObject = (MGameObejct)itemObject[type, i];

            if (mGameObject.active)
            {
                yield return mGameObject.gameObject;
            }
        }
    }
}

