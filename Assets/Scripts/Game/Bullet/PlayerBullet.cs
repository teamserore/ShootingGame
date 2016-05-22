using UnityEngine;
using System.Collections;

public class PlayerBullet : BulletScript {

	void Start () {
        base.bulletInfo.speed = StaticObject.bulletPower;
        //base.bulletInfo.power = StaticObject.playerPower;
    }

    void Update () {
        transform.Translate(Vector2.up * base.bulletInfo.speed * Time.deltaTime); 
    }
}
