using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour {

    public GameObject PauseGUI;
    public Text tvCandy;
    public Text tvScore;
    AudioSource audio;

    void Start() {
        tvCandy.text = PlayerPrefs.GetInt("Candy", 500) + "";
        tvScore.text = PlayerPrefs.GetInt("BestScore", 3) + "";
        BgmManager.instance.PlayMainBgm();
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            SoundEffectManager.instance.PlayButtonClickSound();
            Pause();
        }
    }

    public void Pause()
    {
        SoundEffectManager.instance.PlayButtonClickSound();
        PauseGUI.SetActive(true);
    }
    public void UnPause()
    {
        SoundEffectManager.instance.PlayButtonClickSound();
        PauseGUI.SetActive(false);
    }

    public void Finish() {
        SoundEffectManager.instance.PlayButtonClickSound();
        Application.Quit();
    }

    public void ReadyGo() {
        SoundEffectManager.instance.PlayButtonClickSound();
        MSceneManager.ReadyGo();
    }
}
