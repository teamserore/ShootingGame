using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	protected EnemyStruct enemyInfo;
    protected PlayerScript player;

    // Wave에 따라 달라지는 것들.
    public ItemType itemType;
    public bool hasItem = false;

    void Start (){
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }
		
	protected void Die () {
		EnemyManager.instance.DieEnemy(gameObject);
        if (hasItem) {
            ItemManager.instance.CreateItem(itemType, gameObject);
        }
        GameManager.instance.PlusCandy(enemyInfo.dropCandy);
        GameManager.instance.PlusScore();
	}

    public void DownHP (int hp) {
		enemyInfo.hp -= hp;
		if (enemyInfo.hp <= 0){
			Die ();
		}
	}

    public EnemyStruct getEnemyStruct() {
        return enemyInfo;
    }
}
