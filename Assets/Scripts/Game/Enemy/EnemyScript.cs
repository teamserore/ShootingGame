using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {
	protected EnemyScript enemy;	
	protected EnemyStruct enemyInfo;
	protected PlayerStruct playerInfo;
	protected PlayerScript player;
	protected ItemManager itemManager;
	protected GameManager gameManager;
	protected BoxCollider2D coll = null; // BoxCollider2D

	// Use this for initialization
	void Start () 
	{
		//
	}

	void Awake(){
		coll = GetComponent<BoxCollider2D>(); // BoxCollider2D
		player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	// Update is called once per frame
	void Update () {
		//
	}
		
	protected void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Player"){
			Die ();
		} 
		else if (coll.gameObject.tag == "Bullet"){
			DownHP(playerInfo.power);
		}
	}

	protected void Die () {
		coll.enabled = false;
		transform.localScale = new Vector2 (transform.localScale.x - 0.01f, transform.localScale.y - 0.01f);
		gameObject.SetActive (false);
		gameManager.PlusCandy(enemyInfo.dropCandy);
		//gameManager.PlusScore(enemyInfo.score);
	}

	protected void DownHP (int hp) {
		enemyInfo.hp -= hp;
		if (enemyInfo.hp < 0){
			enemyInfo.hp = 0;
		}
	}
}
