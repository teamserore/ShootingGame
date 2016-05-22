using UnityEngine;
using System.Collections;

public class ItemLife :Item {
    int plusLife;

    void Start() {
        DefSettingIO.getInstance.GetData("PlusLife", out plusLife);
    }

    public void Use() {
        base.player.UpHP(plusLife);
    }

}
