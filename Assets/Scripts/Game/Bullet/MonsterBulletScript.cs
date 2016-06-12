using UnityEngine;
using System.Collections;

public class MonsterBulletScript :MonoBehaviour {
	protected PlayerScript player;
	protected EnemyStruct enemyInfo;
	protected GameManager gameManager;
	protected BoxCollider2D coll = null; // BoxCollider2D


    void Start() {
		coll = GetComponent<BoxCollider2D> ();
		player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
    }

	void Enable() {
		coll.enabled = true;
	}

	void Awake(){
		coll = GetComponent<BoxCollider2D>(); // BoxCollider2D
		player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	protected void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player")
		{
			Die ();
		} 
	}
		
	protected void Die () {
		if(coll == null) {
			coll = GetComponent<BoxCollider2D>() ;
		}
		coll.enabled = false;
		gameObject.SetActive (false);
	}
}
