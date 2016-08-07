using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TobBarManager : MonoBehaviour {

    public GameObject btnPause;
    public GameObject btnSetting;
    public GameObject PauseView;
    public GameObject SettingView;
    public Text tvCandy;
    public Slider soundSlider;
    public Slider bgmSlider;

    void Start () {
        tvCandy.text = PlayerPrefs.GetInt("Candy", 100000) + "";

        bool isGame = false;
        if (Application.loadedLevelName == "Game") {
            isGame = true;
        }
        btnPause.SetActive(isGame);
        btnSetting.SetActive(!isGame);
        soundSlider.onValueChanged.AddListener(delegate {
            GameObject.Find("SoundEffect").GetComponent<SoundEffectManager>().SoundEffectValueChanged(soundSlider.value);
        });
        bgmSlider.onValueChanged.AddListener(delegate {
            GameObject.Find("BGM").GetComponent<BgmManager>().BgmValueChanged(bgmSlider.value);
        });
    }

    public void SetSettingView(bool flag) {
        if (SoundEffectManager.instance != null) {
            SoundEffectManager.instance.PlayButtonClickSound();
        }
        if (flag) {
            soundSlider.value = GameObject.Find("SoundEffect").GetComponent<SoundEffectManager>().GetVolume();
            bgmSlider.value = GameObject.Find("BGM").GetComponent<BgmManager>().GetVolume();
        }
        SettingView.SetActive(flag);
    }

    public void SetPauseView(bool flag) {
        GameManager gameManager = FindObjectOfType<GameManager>();
        if (flag) {
            Time.timeScale = 0;
            gameManager.GS = GameState.Pause;
        } else {
            Time.timeScale = 1;
            gameManager.GS = GameState.Play;
        }
        if (SoundEffectManager.instance != null) {
            SoundEffectManager.instance.PlayButtonClickSound();
        }
        PauseView.SetActive(flag);
    }

    public void MainGo() {
        if (SoundEffectManager.instance != null) {
            SoundEffectManager.instance.PlayButtonClickSound();
        }
        MSceneManager.MainGo();
    }

    public void SetTextCandy(int candy) {
        tvCandy.text = candy + "";
    }
}
