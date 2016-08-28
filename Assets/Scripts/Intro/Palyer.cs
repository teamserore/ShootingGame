using UnityEngine;
using System.Collections;

public class Palyer : MonoBehaviour {

    float PrevPoint_x;
    float PrevPoint_y;
    public float speed = 0.5f;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.touchCount == 1) {
            if (Input.GetTouch(0).phase == TouchPhase.Began) {
                PrevPoint_x = Input.GetTouch(0).position.x * speed;
            }
            if (Input.GetTouch(0).phase == TouchPhase.Moved) {
                gameObject.transform.Rotate(0, ((Input.GetTouch(0).position.x * speed) - PrevPoint_x), 0);
                PrevPoint_x = Input.GetTouch(0).position.x * speed;
            }
        }

    }
}
