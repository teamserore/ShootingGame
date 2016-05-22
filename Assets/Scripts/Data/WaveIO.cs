using UnityEngine;
using System;
using System.Collections.Generic;

public class WaveIO :DataIO {

    private static WaveIO instance;
    public static WaveIO getInstance {
        get {
            if (instance == null) {
                instance = new WaveIO();
            }
            return instance;
        }
    }

    string _baseFileName = "waveList.cvs";
    Dictionary<int, WaveStruct> waveList = new Dictionary<int, WaveStruct>();

    public WaveIO() {
    }

    public override void Load() {
        LoadFile(_baseFileName);
    }

    public override bool VarifyKey(string keyValue) {
        // 애니 이름 여기서 체크
        return true;
    }

    public override void Parse(string[] inputData) {
        int count = 0;
        WaveStruct tempData;
        tempData.index = Convert.ToInt32(inputData[count++]);
        tempData.delayTime = Convert.ToInt32(inputData[count++]);
        tempData.enemyType = Convert.ToInt32(inputData[count++]);
        tempData.respawnType = Convert.ToInt32(inputData[count++]);
        tempData.hp = Convert.ToInt32(inputData[count++]);
        tempData.score = Convert.ToInt32(inputData[count++]);
        tempData.candy = Convert.ToInt32(inputData[count++]);
        tempData.itemType = Convert.ToInt32(inputData[count++]);
        waveList.Add(tempData.index, tempData);

    }

    public bool GetWaveData(int index, out WaveStruct waveData) {
        if (waveList.TryGetValue(index, out waveData) == false) {
            Debug.LogWarning("not existed Data: " + index.ToString());
            return false;
        }
        return true;
    }
}
