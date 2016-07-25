using UnityEngine;
using System.Collections;

public class KniefEnemy : EnemyScript {
    private Vector2 playerPos;
    private SpriteRenderer kniefSprite = null;
    private SpriteRenderer signSprite = null;
    private SpriteRenderer lineSprite = null;
    private GameObject kniefWarningSign = null;
    private GameObject kniefWarningLine = null;

    void Awake() {
        EnemyIO.getInstance.GetEnemyData(EnemyType.KniefEnemy, out enemyInfo);

        kniefSprite = this.gameObject.GetComponent<SpriteRenderer>();
        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;

        kniefWarningSign = GameObject.FindGameObjectWithTag("Sign");
        kniefWarningLine = GameObject.FindGameObjectWithTag("Line");
        signSprite = kniefWarningSign.GetComponent<SpriteRenderer>();
        lineSprite = kniefWarningLine.GetComponent<SpriteRenderer>();

        this.transform.position = new Vector2(playerPos.x, 60.0f);
    }
    IEnumerator Start() {
        kniefSprite.enabled = false;
        yield return StartCoroutine(KniefWarning()); //경고선 처리, 경고느낌표 처리
        kniefSprite.enabled = true;
    }
    void Update() {
        this.transform.Rotate(0.0f, 0.0f, Time.deltaTime * 150); // 회전
        this.transform.position = Vector2.MoveTowards(this.transform.position, playerPos, 0.3f);

        if (this.transform.position.y == playerPos.y) {
            this.gameObject.SetActive(false);
        }
    }
    void OnTriggerEnter2D(Collider2D coll) {
        if (coll.gameObject.tag == "Bomb") {
            Die(); //폭탄과 충돌시 처리
        }
    }
    //나이프경고라인 처리 코루틴
    private IEnumerator KniefWarning() {
        lineSprite.enabled = true;
        kniefWarningLine.transform.position = new Vector2(playerPos.x, 0);
        yield return new WaitForSeconds(2.0f);
        lineSprite.enabled = false;
        //나이프경고사인 처리 코루틴
        signSprite.enabled = true;
        kniefWarningSign.transform.position = new Vector2(playerPos.x, 9.0f);
        yield return new WaitForSeconds(1.0f);
        signSprite.enabled = false;
    }
}