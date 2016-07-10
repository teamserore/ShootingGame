using UnityEngine;
using System.Collections;

public class BgmManager : MonoBehaviour {

    public static BgmManager mInstance;
    public static BgmManager instance {
        get {
            if (mInstance == null) {
                mInstance = FindObjectOfType<BgmManager>();
            }
            return mInstance;
        }

    }

    AudioSource audio;
    // Bgm
    private AudioClip mainBgm = null;
    private AudioClip[] stageBgm = null;

    void Start () {
        DontDestroyOnLoad(gameObject);
        mainBgm = (AudioClip)Resources.Load("Sounds/Bgm/MainBgm") as AudioClip;
        stageBgm = new AudioClip[3];
        stageBgm[0] = (AudioClip)Resources.Load("Sounds/Bgm/Stage1") as AudioClip;
        stageBgm[1] = (AudioClip)Resources.Load("Sounds/Bgm/Stage2") as AudioClip;
        stageBgm[2] = (AudioClip)Resources.Load("Sounds/Bgm/Stage3") as AudioClip;
    }

    public void PlayMainBgm() {
        if(audio == null) {
            audio = GetComponent<AudioSource>();
        }
        audio.clip = mainBgm;
        audio.Play();
    }

    public void PlayGameBgm(int stage) {
        if (audio == null) {
            audio = GetComponent<AudioSource>();
        }
        if(stageBgm[stage] == null) {
            stageBgm[stage] = (AudioClip)Resources.Load("Sounds/stage" + stage) as AudioClip;
        }
        audio.clip = stageBgm[stage];
        audio.Play();
        switch (stage) {
            case 1:
                audio.clip = stageBgm[0];
                break;
            case 2:
                audio.clip = stageBgm[1];
                break;
            case 3:
                audio.clip = stageBgm[2];
                break;
        }
    }

    public void BgmValueChanged(float value) {
        audio.volume = value;
        Debug.Log("valueChanged: "+ value);
    }
}
