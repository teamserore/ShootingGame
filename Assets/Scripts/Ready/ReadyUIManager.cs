using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadyUIManager : MonoBehaviour {
    // TODO(dhUM): 캔디,유저네임 등 상단바에 위치한 UI는 따로 클래스 만들어서 빼기.
    public Text tvCandy;
    public Text tvUserName;

    public GameObject Popup;
    public Text PopupText;
    public GameObject[] btnItem = new GameObject[3];
    public GameObject[] slot = new GameObject[2];
    public GameObject[] btnAdd = new GameObject[2];

    public void SetSlot(int count) {
        if (count == 4) {
            btnAdd[0].SetActive(false);
            btnAdd[1].SetActive(true);
            slot[0].SetActive(true);
        } else if (count == 5) {
            btnAdd[0].SetActive(false);
            btnAdd[1].SetActive(false);
            slot[0].SetActive(true);
            slot[1].SetActive(true);
        }
    }

    public void ShowPopup(int candy) {
        PopupText.text = "캔디 "+ candy + "개가 필요합니다. 구매하시겠습니까?";
        Popup.SetActive(true);
    }

    public void CancelPopup() {
        Popup.SetActive(false);
    }

    public void SetActiveItem(ItemType type, bool flag) {
        btnItem[(int)type].SetActive(flag);  
    }

    public void SetPlayerName(string name) {
        tvUserName.text = name;
    }

    public void SetPalyerCandy(int candy) {
        tvCandy.text = candy + "";
    }
}
