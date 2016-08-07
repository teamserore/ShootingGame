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
    private AudioClip clickSound = null;
    private AudioClip userDieSound = null;
    private AudioClip enemyDieSound = null;
    private AudioClip getItemSound = null;
    private AudioClip useBombItemSound = null;
    private AudioClip usePowerItemSound = null;

    void Start() {
        audio = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
        clickSound = (AudioClip)Resources.Load("Sounds/SoundEffect/click") as AudioClip;
        userDieSound = (AudioClip)Resources.Load("Sounds/SoundEffect/user_die") as AudioClip;
        enemyDieSound = (AudioClip)Resources.Load("Sounds/SoundEffect/enemy_die") as AudioClip;
        getItemSound = (AudioClip)Resources.Load("Sounds/SoundEffect/get_item") as AudioClip;
        useBombItemSound = (AudioClip)Resources.Load("Sounds/SoundEffect/use_bomb_item") as AudioClip;
        usePowerItemSound = (AudioClip)Resources.Load("Sounds/SoundEffect/use_power_item") as AudioClip;
    }

    public void PlayButtonClickSound() {
        audio.clip = clickSound;
        audio.Play();
    }

    public void PlayUserDieSound() {
        audio.clip = userDieSound;
        audio.Play();
    }

    public void PlayEnemyDieSound() {
        audio.clip = enemyDieSound;
        audio.Play();
    }

    public void PlayGetItemSound() {
        audio.clip = getItemSound;
        audio.Play();
    }

    public void PlayUseBombItemSound() {
        audio.clip = useBombItemSound;
        audio.Play();
    }

    public void PlayUsePowerItemSound() {
        audio.clip = usePowerItemSound;
        audio.Play();
    }
    public void SoundEffectValueChanged(float value) {
        audio.volume = value;
    }

    public float GetVolume() {
        return audio.volume;
    }
}
