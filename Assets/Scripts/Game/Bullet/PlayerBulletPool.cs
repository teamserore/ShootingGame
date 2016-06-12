using UnityEngine;
using System.Collections;
using System.Collections.Generic; // Namespace for list type

public class PlayerBulletPool : MonoBehaviour
{

    public List<GameObject> playerBulletprefab = new List<GameObject>(); // Variable that assign bullet prefab
    private Transform playerBulletPoint; // Spawn point of playerBullet
    public List<GameObject> playerBulletPool = new List<GameObject>();
    public float playerBulletFrequency = 0.2f; // Frequency of playerBullet
    private int maxPlayerBullet = 20;


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


        for (int i = 0; i < maxPlayerBullet; i++)
        {
            GameObject playerBullet = (GameObject)Instantiate(playerBulletprefab[0]); // Create bullet prefab
            playerBullet.name = "PlayerBullet_" + i.ToString(); // Set name for created bullet
            playerBullet.SetActive(false); // Make created bullet Inactive
            playerBulletPool.Add(playerBullet); // Add created bullet to Object pool 
        }

        if (playerBulletPoint != null)
        {
            StartCoroutine(this.CreatePlayerBullet()); // Object Pooling
        }

        Debug.Log("asda");
    }

    IEnumerator CreatePlayerBullet()
    {
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

    // Update is called once per frame
    void Update()
    {

    }

}
