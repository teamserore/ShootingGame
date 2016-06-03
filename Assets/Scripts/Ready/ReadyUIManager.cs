using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ReadyUIManager : MonoBehaviour {
    // TODO(dhUM): 캔디,유저네임 등 상단바에 위치한 UI는 따로 클래스 만들어서 빼기.
    public Text tvCandy;

    public GameObject Popup;
    public Text PopupText;
    public GameObject levelLife;
    public GameObject levelPower;
    public GameObject itemPower;
    public GameObject itemBomb;
    
    public void ShowPopup(int candy) {
        PopupText.text = "캔디 "+ candy + "개가 필요합니다. 구매하시겠습니까?";
        Popup.SetActive(true);
    }

    public void dismissPopup() {
        Popup.SetActive(false);
    }

    public void SetPalyerCandy(int candy) {
        tvCandy.text = candy + "";
    }
}
