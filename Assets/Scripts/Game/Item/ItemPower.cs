using UnityEngine;
using System.Collections;

public class ItemPower : Item {
	int feverTimeCount;
	int plusPower;

	// Use this for initialization
	void Start () {
        DefSettingIO.getInstance.GetData("FeverTimeCount", out feverTimeCount);
        DefSettingIO.getInstance.GetData("PlusPower", out plusPower);
    }
	
    public void Use()
    {
        StartCoroutine(FeverTime());
    }

	IEnumerator FeverTime () {
        base.player.UpPower(plusPower);
        yield return new WaitForSeconds(feverTimeCount);
        base.player.DownPower(plusPower-1);
    }
}
