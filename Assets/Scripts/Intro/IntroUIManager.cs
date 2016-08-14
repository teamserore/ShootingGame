using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroUIManager : MonoBehaviour {
    public Text tvBestScore;

	// Use this for initialization
	void Start () {
        tvBestScore.text = PlayerPrefs.GetInt("BestScore", 0) + "";
    }
}
