using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
    public UIManager uiManager;
    public GameManager gameManager;
    public PlayerStruct playerInfo;
	private Vector2 MovePos;

	void Start () {
        playerInfo = new PlayerStruct();
        DefSettingIO.getInstance.GetData("UserSpeed", out playerInfo.speed);

        int powerLevel = PlayerPrefs.GetInt("PowerLevel", 1);
        StatStruct tempData;
        StatIO.getInstance.GetStatData(powerLevel, out tempData);
        playerInfo.power = tempData.power;
        playerInfo.maxHP = PlayerPrefs.GetInt("HP", 1);
        playerInfo.hp = PlayerPrefs.GetInt("HP", 1);
    }

    void Update()
	{
		if (gameManager.getGameState() == GameState.Play) {

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
		if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Bullet") {
			DownHP();
		} 
    }

    public void DownHP(){
        playerInfo.hp -= 1;
        if (playerInfo.hp == 0) {
            Die();
        }
    }

    public int GetPower() {
        return playerInfo.power;
    }

    public void SetPower(int power) {
        playerInfo.power = power;
    }

    private void Die(){
        //TODO(희겸): 플레이어 죽을 때 애니메이션 효과
        Destroy(gameObject);
        gameManager.GameOver();
    }

    public PlayerStruct getPlayerStruct() {
        return playerInfo;
    }
}
