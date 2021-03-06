﻿using UnityEngine;

public class RankingManager : MonoBehaviour
{
    int[] scores = new int[6];

    void Start() {
        scores[0] = PlayerPrefs.GetInt("BestScore", 0);
        scores[1] = PlayerPrefs.GetInt("SecondScore", 0);
        scores[2] = PlayerPrefs.GetInt("ThirdScore", 0);
        scores[3] = PlayerPrefs.GetInt("FourthScore", 0);
        scores[4] = PlayerPrefs.GetInt("Fifthcore", 0);
        scores[5] = PlayerPrefs.GetInt("SixthScore", 0);
    }

    public void SwapRanking(int newScore) {
        int arrayNum = 0;
        for (arrayNum = 5; arrayNum >= 0; arrayNum--) {
            if (scores[arrayNum] < newScore) {
                break;
            }
        }
        switch (arrayNum) {
            case 0:
                PlayerPrefs.SetInt("BestScore", newScore);
                break;
            case 1:
                PlayerPrefs.SetInt("SecondScore", newScore);
                break;
            case 2:
                PlayerPrefs.SetInt("ThirdScore", newScore);
                break;
            case 3:
                PlayerPrefs.SetInt("FourthScore", newScore);
                break;
            case 4:
                PlayerPrefs.SetInt("FifthScore", newScore);
                break;
            case 5:
                PlayerPrefs.SetInt("SixthScore", newScore);
                break;
            default:
                Debug.Log("RankingManger arraynum 에러");
                break;
        }
    }
}
