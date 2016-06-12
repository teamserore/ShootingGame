﻿using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	protected EnemyStruct enemyInfo;
    protected PlayerScript player;
	protected BoxCollider2D coll = null;

    // Wave에 따라 달라지는 것들.
    public ItemType itemType;
    public bool hasItem = false;

    void Start (){
		coll = GetComponent<BoxCollider2D> ();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }

	void Enable (){
		coll.enabled = true;
	}

	protected void Die () {
		if(coll == null) {
			coll = GetComponent<BoxCollider2D>() ;
		}

		coll.enabled = false;
		EnemyManager.instance.DieEnemy(gameObject);
        if (hasItem) {
            ItemManager.instance.CreateItem(itemType, gameObject);
            Debug.Log("hasItem:true");
        }
        GameManager.instance.PlusCandy(enemyInfo.dropCandy);
        GameManager.instance.PlusScore();
	}

	public void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player"){
			Die ();
		} 
		else if (coll.gameObject.tag == "PlayerBullet"){
			DownHP(1); //에러
		}
	}

    public void DownHP (int hp) {
		enemyInfo.hp -= hp;
		if (enemyInfo.hp <= 0){
			Die ();
		}
	}
}
