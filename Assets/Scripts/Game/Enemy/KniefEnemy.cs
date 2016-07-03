using UnityEngine;
using System.Collections;

public class KniefEnemy : EnemyScript {
    private Vector2 playerPos;
    private SpriteRenderer kniefSprite = null;
    private GameObject kniefWarningSign = null;
    private GameObject kniefWarningLine = null;

    void Awake() {
        EnemyIO.getInstance.GetEnemyData(EnemyType.KniefEnemy, out enemyInfo);
        kniefSprite = this.gameObject.GetComponent<SpriteRenderer>();
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>().position;
        kniefWarningLine = GameObject.Find("KniefWarningLine");
        kniefWarningSign = GameObject.Find("KniefWarningSign");
        kniefWarningLine.SetActive(false);
        kniefWarningSign.SetActive(false);
    }
    IEnumerator Start() {
        //밑으로 진행
        kniefSprite.enabled = false;
        StartCoroutine(KniefWarningLine()); //경고선 처리
        StartCoroutine(KniefWarningSign()); //경고느낌표 처리
        yield return new WaitForSeconds(1.1f);
        kniefSprite.enabled = true;
        this.transform.position = new Vector2(playerPos.x, 9.0f);
        this.transform.Translate(Vector2.down * Time.deltaTime * enemyInfo.speed); // 아래로 진행
    }
    void Update() {
        this.transform.Rotate(0.0f, 0.0f, Time.deltaTime * 150); // 회전
    }

    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Bomb") {
            Die(); //폭탄과 충돌시 처리
        }
        else if (coll.gameObject.tag == "Player") {
            //player.DownHP(100); // Player와 충돌시 처리
        }
    }
    //나이프경고라인 처리 코루틴
    private IEnumerator KniefWarning() {
        kniefWarningLine.SetActive(true);
        kniefWarningLine.transform.position = new Vector2(playerPos.x, 0);
        yield return new WaitForSeconds(2.0f);
        kniefWarningLine.SetActive(false);
    //나이프경고사인 처리 코루틴
        kniefWarningSign.SetActive(true);
        kniefWarningSign.transform.position = new Vector2(playerPos.x, 9.0f);
        yield return new WaitForSeconds(2.0f);
        kniefWarningSign.SetActive(false);
    }
}