using UnityEngine;
using System.Collections;

public class IntroManager : MonoBehaviour {
    public GameObject ExitView;

    void Start() {
        BgmManager.instance.PlayMainBgm();
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            SoundEffectManager.instance.PlayButtonClickSound();
            SetExitView(true);
        }
    }

    public void SetExitView(bool flag)
    {
        SoundEffectManager.instance.PlayButtonClickSound();
        ExitView.SetActive(flag);
    }

    public void Finish() {
        SoundEffectManager.instance.PlayButtonClickSound();
        Application.Quit();
    }

    public void ReadyGo() {
        Debug.Log("RedayGO");
        SoundEffectManager.instance.PlayButtonClickSound();
        MSceneManager.ReadyGo();
    }
}
