using UnityEngine;
using System.Collections;
//using UnityEngine.SceneManagement;

public class MSceneManager : MonoBehaviour {

    public static MSceneManager mInstance;
    public static MSceneManager instance {
        get {
            if (mInstance == null) {
                mInstance = FindObjectOfType<MSceneManager>();
            }
            return mInstance;
        }

    }
    public static void MainGo () {
        Time.timeScale = 1;

        //SceneManager.LoadSceneAsync(0);
    }

    public static void ReadyGo (){
        Time.timeScale = 1;
        //SceneManager.LoadSceneAsync(1);
    }

    public static void GameGo()
    {
        Time.timeScale = 1;
        //SceneManager.LoadSceneAsync(2);
    }
}
