using UnityEngine;
using System.Collections;

public class AimedBullet : MonsterBulletScript {
	Vector2 relativePos;
	float angle;
	float bulletAngle;
	int count;

	// Use this for initialization
	void Start () {
		//
	}

	// Update is called once per frame
	void Update () {
		count++;
		if (count == 10) {
			relativePos = player.transform.position - this.transform.position;
			angle = Mathf.Atan2 (relativePos.y, relativePos.x) * Mathf.Rad2Deg;
			bulletAngle = Random.Range (80, 100); // random angle between 80 ~ 100 (20) 
		} else if (count > 10) {
			transform.localRotation = Quaternion.Euler (0, 0, angle - bulletAngle);
			transform.Translate (transform.up * 10 * Time.deltaTime, Space.World);
			//speed fix neeeeded
		}
	}
}
