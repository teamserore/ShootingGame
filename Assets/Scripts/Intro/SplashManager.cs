using UnityEngine;
using System.Collections;

public class SplashManager : MonoBehaviour {
	public float delayTime = 2;

	//Using this for initialization
	IEnumerator Start(){
		yield return new WaitForSeconds (delayTime);

		Application.LoadLevel ("Intro");	
	}
}

