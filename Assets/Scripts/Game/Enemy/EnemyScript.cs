using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	protected EnemyStruct enemyInfo;
	public PlayerStruct playerInfo;
    protected PlayerScript player;
	protected BoxCollider2D coll = null;
	protected int HP;
	private int power;

    // Wave에 따라 달라지는 것들.
    public ItemType itemType;
    public bool hasItem = false;

    void Start (){
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }
		
	void OnEnable(){
		coll = GetComponent<BoxCollider2D> ();
		coll.enabled = true;
	}

	protected void Die () {
		EnemyManager.instance.DieEnemy(gameObject);
        if (hasItem) {
            ItemManager.instance.CreateItem(itemType, gameObject);
        }
        GameManager.instance.PlusCandy(enemyInfo.dropCandy);
        GameManager.instance.PlusScore();
	}

    public void DownHP (int damage) {
		HP -= damage;
		if (HP <= 0){
			Die ();
		}
	}

	public void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player") {
			Die();
		} else if (coll.gameObject.tag == "PlayerBullet") {
			power = playerInfo.power;
			DownHP(power);
		} else if (coll.gameObject.tag == "Bomb") {
			Die();
		}
	}

    public EnemyStruct getEnemyStruct() {
        return enemyInfo;
    }
}
