using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour {

    public GameObject PauseGUI;
    public Text tvCandy;
    public Text tvScore;
    public Text tvUserName;
    public Text tvRank;

    void Start() {
        tvCandy.text = PlayerPrefs.GetInt("Candy", 500) + "";
        tvScore.text = PlayerPrefs.GetInt("BestScore", 3) + "점";
        tvUserName.text = PlayerPrefs.GetString("UserName", "RAON");
        tvRank.text = PlayerPrefs.GetInt("Rank", 1) + "위";
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
