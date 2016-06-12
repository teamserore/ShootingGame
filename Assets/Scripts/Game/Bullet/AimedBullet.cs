﻿using UnityEngine;
using System.Collections;

public class AimedBullet : MonoBehaviour {
	float speed = 8f;
	public PlayerScript player;
	protected EnemyScript enemyScript;
	protected EnemyStruct enemyInfo;
	Vector2 relativePos;
	float angle;
	float bulletAngle;
	int count;

	public GameManager gameManager;

	// Use this for initialization
	void Start () {
		//Destroy (this.gameObject, 4f);	// delete itself
		player = GameObject.FindWithTag("Player").GetComponent<PlayerScript>();
	}

	// Update is called once per frame
	void Update () {
		if (enemyInfo.hp > 0) {
			count++;
			if (count == 10) {
				relativePos = player.transform.position - this.transform.position;
				angle = Mathf.Atan2 (relativePos.y, relativePos.x) * Mathf.Rad2Deg;
				bulletAngle = Random.Range (80, 100); // random angle between 80 ~ 100 (20) 
			} else if (count > 10) {
				transform.localRotation = Quaternion.Euler (0, 0, angle - bulletAngle);
				transform.Translate (transform.up * speed * Time.deltaTime, Space.World);
			}
		}
	}
}
