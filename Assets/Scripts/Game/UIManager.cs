﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager :MonoBehaviour {

    public GameManager gameManager;
    Sprite PowerIcon;
    Sprite BombIcon;
    public Slider PlayerHpSlider;
    public GameObject[] ItemSlot = new GameObject[PlayerPrefs.GetInt("SlotCount", 3)];
    public GameObject InGameView;
    public GameObject PauseView;
    public GameObject ResultView;
    public Text tvCandy;
    public Text tvScore;
    public Text tvResultCandy;
    public Text tvResultScore;
    public Text tvBestScore;
    public GameObject PlusCandyInGame;
    public Text tvPlusCandyInGame;

    public void UpPlayerHpSlider(int hp) {
        PlayerHpSlider.value += hp / 100f;
    }

    public void DownPlayerHpSlider(int hp) {
        PlayerHpSlider.value += hp / 100f;
    }

    public void AddItemToSlot(Item item, int pos) {
        if (item.GetType() == typeof(ItemPower)) {
            ItemSlot[pos].GetComponent<Image>().sprite = PowerIcon;
            return;
        }
        ItemSlot[pos].GetComponent<Image>().sprite = BombIcon;
    }

    public void UseItemFromSlot(int pos) {
        gameManager.UseItem(pos);
        // 선택된 위치의 슬롯 뒤의 아이템들을 앞으로 옮겨준다.
        for (int i = pos; i < gameManager.getSlotCount(); i++) {
            ItemSlot[i].GetComponent<Image>().sprite = ItemSlot[i + 1].GetComponent<Image>().sprite;
        }
        // 제일 마지막 슬롯은 항상 비어있다.
        ItemSlot[gameManager.getSlotCount()].GetComponent<Image>().sprite = null;
    }

    public void SetInGameView(bool flag) {
        InGameView.SetActive(flag);
    }

    public void SetResultView(bool flag) {
        ResultView.SetActive(flag);
    }

    public void SetPauseView(bool flag) {
        PauseView.SetActive(flag);
    }

    public void SetPlusCandy(bool flag) {
        PlusCandyInGame.SetActive(flag);
    }

    public void SetTextPlusCandy(int candy) {
        tvPlusCandyInGame.text = candy + " candy";
    }

    public void SetTextCandy(int candy) {
        tvCandy.text = candy + "";
    }

    public void SetTextScore(int score) {
        tvScore.text = score + "";
    }

    public void SetTextResultCandy(int candy) {
        tvResultCandy.text = candy + "";
    }

    public void SetTextResultScore(int score) {
        tvResultScore.text = score + "";
    }

    public void SetTextBestScore(int score) {
        tvBestScore.text = score + "";
    }
}