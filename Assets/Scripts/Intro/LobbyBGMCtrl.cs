using UnityEngine;
using System.Collections;

/*
 * 
 * created by Heekyum kwon
 * class for BGM in Lobby
 * 2016.03.29
 * 
 * 
 *
 */

public class LobbyBGMCtrl : MonoBehaviour {
	public AudioClip ButtonSound = null; // 버튼 클릭
	public AudioClip ReadySound = null; // 게임 준비 버튼 클릭
	public AudioClip StartSound = null; // 게임 시작 버튼 클릭
	public AudioClip UpgradeSound = null; // 업그레이드

	// Use this for initialization
	void Start () {
			DontDestroyOnLoad (gameObject);
	}
		
	// Update is called once per frame	
	void Update () {
		if (Application.loadedLevelName == "Game") {
			Destroy (gameObject);
		}
	}
}
