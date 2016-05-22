using UnityEngine;
using System.Collections;
using System.Collections.Generic; // Namespace for list type

public class PlayerBulletPool : MonoBehaviour {

    public GameObject playerBulletprefab; // Variable that assign bullet prefab
    public Transform playerBulletPoint; // Spawn point of playerBullet
    public List<GameObject> playerBulletPool = new List<GameObject>();
    public float playerBulletFrequency = 2.0f; // Frequency of playerBullet
    private int maxPlayerBullet = 10;

    // Use this for initialization
    void Start()
    {
        playerBulletPoint = GameObject.Find("FirePos").GetComponentInChildren<Transform>();
        for (int i = 0; i < maxPlayerBullet; i++)
        {
            GameObject playerBullet = (GameObject)Instantiate(playerBulletprefab); // Create bullet prefab
            playerBullet.name = "PlayerBullet_" + i.ToString(); // Set name for created bullet
            playerBullet.SetActive(false); // Make created bullet Inactive
            playerBulletPool.Add(playerBullet); // Add created bullet to Object pool 
        }

        if (playerBulletPoint != null)
        {
            StartCoroutine(this.CreatePlayerBullet()); // Object Pooling
        }
    }

    IEnumerator CreatePlayerBullet()
    {
        //while (!isGameOver) // Repeat until game over 
        //{
            yield return new WaitForSeconds(playerBulletFrequency); // yield time to main loop
        //    if (isGameOver) { yield break; } // Break coroutine when game over

        //    foreach (GameObject playerBullet in playerBulletPool)
        //    {
        //        if (!playerBullet.activeSelf)
        //        {
        //            playerBullet.transform.position = playerBulletPoint.position; // Set Bullet's spawn point
        //            playerBullet.SetActive(true);
        //            break;
        //        }
        //    }
        //}
    }

    // Update is called once per frame
    void Update()
    {

    }

}
