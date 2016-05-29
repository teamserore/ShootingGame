using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    UIManager uiManager;
	GameManager gameManager;
    public PlayerStruct playerInfo;
	EnemyStruct enemyInfo;
	BulletStruct bulletInfo;
	//BulletPool bulletPool;
	GameState GS;
	private Vector2 MovePos;
	private float time;
	private float attackCoolTime;

	void Start () {
        playerInfo = new PlayerStruct();

        int powerLevel = PlayerPrefs.GetInt("PowerLevel", 1);
        int lifeLevel = PlayerPrefs.GetInt("LifeLevel", 1);
 
        StatStruct tempData;
        StatIO.getInstance.GetStatData(powerLevel, out tempData);
        playerInfo.power = tempData.power;
        StatIO.getInstance.GetStatData(lifeLevel, out tempData);
        playerInfo.maxHP = tempData.life;
        playerInfo.hp = tempData.life;

        DefSettingIO.getInstance.GetData("UserSpeed", out playerInfo.speed);
		attackCoolTime = 0.5f;
		time = 0;
    }

	void Awake (){
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	void Update()
	{
		if (GS == GameState.Play) {

			transform.position = new Vector3(Mathf.Clamp(transform.position.x, -5.0f, 5.0f), Mathf.Clamp(transform.position.y, -10.0f, 10.0f), 0); 
			
			// keyboard move
			if (Input.GetKey (KeyCode.LeftArrow)){
				transform.Translate (Vector2.left * playerInfo.speed * Time.deltaTime);
			}
			if (Input.GetKey (KeyCode.RightArrow)){
				transform.Translate (Vector2.right * playerInfo.speed * Time.deltaTime);
			}
			if (Input.GetKey (KeyCode.UpArrow)){
				transform.Translate (Vector2.up * playerInfo.speed * Time.deltaTime);
			}
			if (Input.GetKey (KeyCode.DownArrow)){
				transform.Translate (Vector2.down * playerInfo.speed * Time.deltaTime);
			}

			// touch move
			if (Input.touchCount > 0) {
				if (Input.GetTouch (0).phase == TouchPhase.Began){
					//check touch
				} 
				else if (Input.GetTouch (0).phase == TouchPhase.Moved){
					//check touch with drag
					MovePos = Input.GetTouch (0).deltaPosition;
					transform.Translate (MovePos.x * playerInfo.speed * 0.01f, MovePos.y * playerInfo.speed * 0.01f, 0);
				} 
				else if (Input.GetTouch (0).phase == TouchPhase.Stationary){
					//check move after touch
				} 
				else if (Input.GetTouch (0).phase == TouchPhase.Ended){
					//check touch stop
					//Debug.Log ("Stop");
				}
			}

			if (playerInfo.hp <= 0) {
				//Die ();
				//데이터 받아오기 전까지 주석
			}
		}
    }

    void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Enemy"){
			DownHP(enemyInfo.power);
		} 
		else if (coll.gameObject.tag == "Bullet"){
			DownHP(bulletInfo.power);
		}
    }

    public void UpHP(int hp){
        playerInfo.hp += hp;
        if (playerInfo.hp > playerInfo.maxHP){
            playerInfo.hp = playerInfo.maxHP;
        }
        uiManager.UpPlayerHpSlider(playerInfo.hp);
    }

    public void DownHP(int hp){
        playerInfo.hp -= hp;
        if (playerInfo.hp < 0){
            playerInfo.hp = 0;
        }
        uiManager.DownPlayerHpSlider(playerInfo.hp);
    }

    public void UpPower(int power){
        playerInfo.power += power;
    }

    public void DownPower(int power){
        playerInfo.power += power;
    }

    void Attack(){
		//bulletPool.NewBullet (3, respawn);
    }

    void Die(){
		transform.localScale = new Vector2 (transform.localScale.x - 0.01f, transform.localScale.y - 0.01f);
		if (transform.localScale.x <= 0) {
			Destroy (this.gameObject); // delete player
			gameManager.GameOver ();
		}
	}

    public PlayerStruct getPlayerStruct() {
        return playerInfo;
    }
}
