using UnityEngine;
using System.Collections;

// bgm은 clip만 관리한다.
// 효과음은 직접 재생한다.
public class SoundEffectManager : MonoBehaviour {

    public static SoundEffectManager mInstance;
    public static SoundEffectManager instance {
        get {
            if (mInstance == null) {
                mInstance = FindObjectOfType<SoundEffectManager>();
            }
            return mInstance;
        }

    }

    AudioSource audio;
    // SoundEffect
    private AudioClip buttonClick = null;

    private AudioClip playerShot = null;

    void Start() {
        audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        buttonClick = (AudioClip)Resources.Load("Sounds/SoundEffect/click") as AudioClip;
        playerShot = (AudioClip)Resources.Load("Sounds/SoundEffect/shot") as AudioClip;
    }

    public void PlayButtonClickSound() {
        audio.clip = buttonClick;
        audio.Play();
    }

    public void PlayBulletSound() {
        audio.clip = playerShot;
        audio.Play();
    }

    public void SoundEffectValueChanged(float value) {
        audio.volume = value;
    }
}
