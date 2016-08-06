using UnityEngine;
using System.Collections;
using System.Collections.Generic; // Namespace for list type

public class PlayerBulletPool : MonoBehaviour {
    PlayerScript playerScript;
    public List<GameObject> playerBulletprefab = new List<GameObject>(); // Variable that assign bullet prefab
    private Transform playerBulletPoint; // Spawn point of playerBullet
    public List<GameObject> playerBulletPool = new List<GameObject>();
    private float playerBulletFrequency = 0.1f; // Frequency of playerBullet
    private int maxPlayerBullet = 11;
    private int currentPowerLV; // +1한 값이 실제 레벨



    void Start() {
        playerBulletPoint = GameObject.Find("FirePos").GetComponentInChildren<Transform>(); //발사위치확인
        /*프리팹 연결*/
        playerBulletprefab[0] = Resources.Load("Prefabs/PlayerBullet0") as GameObject;
        playerBulletprefab[1] = Resources.Load("Prefabs/PlayerBullet1") as GameObject;
        playerBulletprefab[2] = Resources.Load("Prefabs/PlayerBullet2") as GameObject;
        playerBulletprefab[3] = Resources.Load("Prefabs/PlayerBullet3") as GameObject;
        playerBulletprefab[4] = Resources.Load("Prefabs/PlayerBullet4") as GameObject;
        playerBulletprefab[5] = Resources.Load("Prefabs/PlayerBullet5") as GameObject;
        playerBulletprefab[6] = Resources.Load("Prefabs/PlayerBullet6") as GameObject;
        playerBulletprefab[7] = Resources.Load("Prefabs/PlayerBullet7") as GameObject;
        playerBulletprefab[8] = Resources.Load("Prefabs/PlayerBullet8") as GameObject;
        playerBulletprefab[9] = Resources.Load("Prefabs/PlayerBullet9") as GameObject;
        playerBulletprefab[10] = Resources.Load("Prefabs/PlayerBullet10") as GameObject;
        /*현재 파워 검사  */
		currentPowerLV = PlayerPrefs.GetInt("PowerLevel", 1);

        for (int i = 0; i < 11 - currentPowerLV; i++) {

            for (int j = 0; j < maxPlayerBullet; j++) {
                GameObject playerBullet = (GameObject)Instantiate(playerBulletprefab[i + currentPowerLV]); // Create bullet prefab
                playerBullet.name = (i + currentPowerLV).ToString(); // Set name for created bullet
                playerBullet.SetActive(false); // Make created bullet Inactive
                playerBulletPool.Add(playerBullet); // Add created bullet to Object pool 
            }
        }
        if (playerBulletPoint != null) {
            StartCoroutine(this.CreatePlayerBullet(currentPowerLV)); // Object Pooling
        }
    }

	public void UpgradeLevel()
	{
		if(currentPowerLV < 10)
		currentPowerLV++;

	}

	public void DowngradeLevel(int level)
	{
		currentPowerLV = level;
		currentPowerLV --;
	}
	public void MaxPower()
	{
		currentPowerLV = 10;

	}

    public IEnumerator CreatePlayerBullet(int level) {
        while (GameManager.instance.GS != GameState.End) { // Repeat until game over 
            yield return new WaitForSeconds(playerBulletFrequency); // yield time to main loop
            if (GameManager.instance.GS == GameState.End) { yield break; } // Break coroutine when game over
            foreach (GameObject playerBullet in playerBulletPool) {
				if (!playerBullet.activeSelf && playerBullet.name == currentPowerLV.ToString()) {
                    playerBullet.transform.position = playerBulletPoint.position; // Set Bullet's spawn point
                    playerBullet.GetComponent<BoxCollider2D>().enabled = true;
                    playerBullet.SetActive(true);
                    break;
                }
            }
        }
    }

	public int ReturnCurrentPower()
	{
		return currentPowerLV;
	}

    public int CheckPowerLv(int pw) {
        if (pw == 10) { return 0; }
        else if (pw == 14){ return 1; }
        else if (pw == 18){ return 2; }
        else if (pw == 22){ return 3; }
        else if (pw == 26){ return 4; }
        else if (pw == 30){ return 5; }
        else if (pw == 34){ return 6; }
        else if (pw == 38){ return 7; }
        else if (pw == 42){ return 8; }
        else if (pw == 46){ return 9; }
        else if (pw == 200){ return 10; }
        else {
            Debug.Log("플레이어 탄 레벨 에러");
            return -1;
        }
    }
}
