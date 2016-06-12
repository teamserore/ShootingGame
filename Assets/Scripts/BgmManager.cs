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
    private AudioClip stageBgm1 = null;
    private AudioClip stageBgm2 = null;
    private AudioClip stageBgm3 = null;

    void Start () {
        audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        mainBgm = (AudioClip)Resources.Load("Sounds/Bgm/MainBgm") as AudioClip;
        stageBgm1 = (AudioClip)Resources.Load("Sounds/Bgm/Stage1") as AudioClip;
        stageBgm2 = (AudioClip)Resources.Load("Sounds/Bgm/Stage2") as AudioClip;
        stageBgm3 = (AudioClip)Resources.Load("Sounds/Bgm/Stage3") as AudioClip;
    }

    public void PlayMainBgm() {
        audio.clip = mainBgm;
        audio.Play();
    }

    public void PlayGameBgm(int stage) {
        switch (stage) {
            case 1:
                audio.clip = stageBgm1;
                break;
            case 2:
                audio.clip = stageBgm2;
                break;
            case 3:
                audio.clip = stageBgm3;
                break;
        }
        audio.Play();
    }
}
