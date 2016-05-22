using UnityEngine;
using System.Collections;

public class BulletScript :MonoBehaviour {
    protected BulletStruct bulletInfo;
	protected EnemyScript enemy;	
	protected EnemyStruct enemyInfo;
	protected PlayerStruct playerInfo;
	protected PlayerScript player;
	protected ItemManager itemManager;
	protected GameManager gameManager;
	protected BoxCollider2D collider = null; // BoxCollider2D


    void Start() {
        
    }

	void Awake(){
		collider = GetComponent<BoxCollider2D>(); // BoxCollider2D
		player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	protected void OnTriggerEnter2D (Collider2D coll) 
	{
		if (coll.gameObject.tag == "Player")
		{
			Die ();
		} 
	}
		
	protected void Die () 
	{
		collider.enabled = false;
		transform.localScale = new Vector2 (transform.localScale.x - 0.01f, transform.localScale.y - 0.01f);
		gameObject.SetActive (false);
		gameManager.PlusCandy(enemyInfo.dropCandy);
		//gameManager.PlusScore(enemyInfo.score);
	}
}
