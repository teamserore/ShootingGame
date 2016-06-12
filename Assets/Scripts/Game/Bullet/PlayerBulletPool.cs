using UnityEngine;
using System.Collections;
using System.Collections.Generic; // Namespace for list type

public class PlayerBulletPool : MonoBehaviour
{
    public PlayerStruct playerInfo;
    public List<GameObject> playerBulletprefab = new List<GameObject>(); // Variable that assign bullet prefab
    private Transform playerBulletPoint; // Spawn point of playerBullet
    public List<GameObject> playerBulletPool = new List<GameObject>();
    public float playerBulletFrequency = 0.1f; // Frequency of playerBullet
    private int maxPlayerBullet = 17;
    private int currentPowerLV;

    void Awake()
    {
        currentPowerLV = CheckPowerLv(playerInfo.power);
    }

    // Use this for initialization
    void Start()
    {
        playerBulletPoint = GameObject.Find("FirePos").GetComponentInChildren<Transform>();

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


        for (int i = 0; i < 11 - currentPowerLV; i++) {
            for (int j = 0; j < maxPlayerBullet; j++) {
                GameObject playerBullet = (GameObject)Instantiate(playerBulletprefab[i + currentPowerLV]); // Create bullet prefab
                playerBullet.name = "PlayerBullet_" + (i + currentPowerLV) + "_" + j; // Set name for created bullet
                playerBullet.SetActive(false); // Make created bullet Inactive
                playerBulletPool.Add(playerBullet); // Add created bullet to Object pool 
            }
        }
        print(";ev : " +( 11 - currentPowerLV));
        if (playerBulletPoint != null) {
            StartCoroutine(this.CreatePlayerBullet()); // Object Pooling
        }
    }

    IEnumerator CreatePlayerBullet() {
        while (GameManager.instance.GS != GameState.End) // Repeat until game over 
        {
            yield return new WaitForSeconds(playerBulletFrequency); // yield time to main loop
            if (GameManager.instance.GS == GameState.End) { yield break; } // Break coroutine when game over

            foreach (GameObject playerBullet in playerBulletPool)
            {
                if (!playerBullet.activeSelf)
                {
                    playerBullet.transform.position = playerBulletPoint.position; // Set Bullet's spawn point
                    playerBullet.SetActive(true);
                    break;
                }
            }
        }
    }
    int CheckPowerLv(float pw)
    { //TODO(shBOO)함수 수정
        if (pw == 1.0f)
        {
            return 0;
        }
        else if (pw == 1.4f)
        {
            return 1;
        }
        else if (pw == 1.8f)
        {
            return 2;
        }
        else if (pw == 2.2f)
        {
            return 3;
        }
        else if (pw == 2.6f)
        {
            return 4;
        }
        else if (pw == 3.0f)
        {
            return 5;
        }
        else if (pw == 3.4f)
        {
            return 6;
        }
        else if (pw == 3.8f)
        {
            return 7;
        }
        else if (pw == 4.2f)
        {
            return 8;
        }
        else if (pw == 4.6f)
        {
            return 9;
        }
        else if (pw == 20.0f)
        {
            return 10;
        }
        else {
            Debug.Log("플레이어 탄 레벨 에러");
            return -1;
        }
    }
    // Update is called once per frame
}
