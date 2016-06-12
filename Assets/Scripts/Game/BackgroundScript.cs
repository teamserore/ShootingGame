using UnityEngine;
using System.Collections;

public class BackgroundScript :MonoBehaviour {


    public float ScrollSpeed = 0.1f;
    float Offset;
    Renderer mRenderer;

    void Start() {
        mRenderer = GetComponent<Renderer>();
    }

    void Update() {
        if (GameManager.instance.GS == GameState.Play) {
            Offset += Time.deltaTime * ScrollSpeed;
            mRenderer.material.mainTextureOffset = new Vector2(0, Offset);
        }
    }
}
