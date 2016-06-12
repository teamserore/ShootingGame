using UnityEngine;
using System.Collections;

public class DirectionBullet : MonsterBulletScript {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.down * Time.deltaTime * enemyInfo.speed); // move down
	}
}
