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

    AudioSource mAudio;
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
        if(mAudio == null) {
            mAudio = GetComponent<AudioSource>();
        }
        mAudio.clip = mainBgm;
        mAudio.Play();
    }

    public void PlayGameBgm(int stage) {
        if (mAudio == null) {
            mAudio = GetComponent<AudioSource>();
        }
        switch (stage) {
            case 1:
                mAudio.clip = stageBgm[0];
                break;
            case 2:
                mAudio.clip = stageBgm[1];
                break;
            case 3:
                mAudio.clip = stageBgm[2];
                break;
        }

        if (mAudio.clip == null) {
            mAudio.clip = (AudioClip)Resources.Load("Sounds/stage" + stage) as AudioClip;
        }
        mAudio.Play();
    }

    public void BgmValueChanged(float value) {
        mAudio.volume = value;
        Debug.Log("valueChanged: "+ value);
    }

    public float GetVolume() {
        return mAudio.volume;
    }
}
