using UnityEngine;
using System.Collections;

public class KniefEnemy : EnemyScript {
    private Transform playerTr = null;
    private SpriteRenderer kniefSprite = null;
    public GameObject kniefWarningSign = null;
    public GameObject kniefWarningLine = null;

    void Awake() {
        EnemyIO.getInstance.GetEnemyData(EnemyType.KniefEnemy, out enemyInfo);
        kniefSprite = this.gameObject.GetComponent<SpriteRenderer>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //경고선 처리
        StartCoroutine(KniefWarningLine());
        //경고느낌표 처리
        StartCoroutine(KniefWarningSign());
    }
    IEnumerator Start() {
        //밑으로 진행
        //kniefSprite.enabled = false; //이미지 안보이게 
        yield return new WaitForSeconds(9.0f);
        //kniefSprite.enabled = true;
        //this.transform.position = new Vector2(playerTr.position.x, 9.0f);
        //this.transform.Translate(Vector2.down * Time.deltaTime * enemyInfo.speed); // 아래로 진행
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
    private IEnumerator KniefWarningLine() {
        kniefWarningLine.SetActive(true);
        kniefWarningLine.transform.position = new Vector2(playerTr.position.x, 0);
        yield return new WaitForSeconds(4.0f);
        kniefWarningLine.SetActive(false);
    }
    //나이프경고사인 처리 코루틴
    private IEnumerator KniefWarningSign() {
        kniefWarningSign.SetActive(true);
        kniefWarningSign.transform.position = new Vector2(playerTr.position.x, 9.0f);
        yield return new WaitForSeconds(5.0f);
        kniefWarningSign.SetActive(false);
    }
}