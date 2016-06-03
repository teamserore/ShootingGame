using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour {

    public GameObject PauseGUI;
    public Text tvCandy;
    public Text tvScore;

    void Start() {
        tvCandy.text = PlayerPrefs.GetInt("Candy", 500) + "";
        tvScore.text = PlayerPrefs.GetInt("BestScore", 3) + "";
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            Pause();
        }
    }

    public void Pause()
    {
        PauseGUI.SetActive(true);
    }
    public void UnPause()
    {
        PauseGUI.SetActive(false);
    }

    public void Finish() {
        Application.Quit();
    }

    public void ReadyGo() {
        MSceneManager.ReadyGo();
    }
}
