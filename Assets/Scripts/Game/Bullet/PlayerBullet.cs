using UnityEngine;
using System.Collections;

public class PlayerBullet : BulletScript {

	void Start () {
        base.bulletInfo.speed = 10.0f;
        //base.bulletInfo.power = StaticObject.playerPower;
        
    }

    void Update () {
        transform.Translate(Vector2.up * base.bulletInfo.speed * Time.deltaTime);

        if (transform.position.y >= 20) {
            this.Die();
        }
    }

    bool OnTriggerEnter2D(Collider2D coll) //피격처리
    {
        if(coll.gameObject.tag == "Enemy") {
            this.Die();
            Debug.Log("총알 에너미 접촉");
            return true;
        }
        return false;
    }

    void Die()
    {
        //TODO(shBOO)캔디점수추가
        StartCoroutine(this.PushObjectPool());
    }

        IEnumerator PushObjectPool() {
        yield return new WaitForSeconds(0.0f);

        //bulletInfo.power = playerInfo.power;
        //CheckPowerLv();
        //TODO(shBOO) 플레이어 탄의 power에 따라 프리팹 바꿔주기

        gameObject.SetActive(false);
    }
    //void CheckPowerLv() //TODO(shBOO)함수 수정
    //{
    //    if (0 < playerInfo.power && playerInfo.power <= 2.2) {/*TODO (shBOO)첫 번째 오브젝트 풀링*/ }
    //    else if (2.2 < playerInfo.power && playerInfo.power <= 3.8) {/*TODO (shBOO)두 번째 오브젝트 풀링*/ }
    //    else if (3.8 < playerInfo.power && playerInfo.power <= 4.6) {/*TODO (shBOO)세 번째 오브젝트 풀링*/ }
    //    else { Debug.Log("플레이어 탄 레벨 에러"); }
    //}
}
