using UnityEngine;
using System;
using System.Collections.Generic;

public class StatIO :DataIO {

    private static StatIO instance;
    public static StatIO getInstance {
        get {
            if (instance == null) {
                instance = new StatIO();
            }
            return instance;
        }
    }

    string _baseFileName = "statList.cvs";
    Dictionary<int, StatStruct> statList = new Dictionary<int, StatStruct>();

    public StatIO() {
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
        StatStruct tempData;
        tempData.index = Convert.ToInt32(inputData[count++]);
        tempData.power = Convert.ToInt32(inputData[count++]);
        tempData.candyForPower = Convert.ToInt32(inputData[count++]);
        tempData.life = Convert.ToInt32(inputData[count++]);
        tempData.candyForLife = Convert.ToInt32(inputData[count++]);
        statList.Add(tempData.index, tempData);
    }

    public bool GetStatData(int index, out StatStruct statData) {
        if (statList.TryGetValue(index, out statData) == false) {
            Debug.LogWarning("not existed Data: " + index.ToString());
            return false;
        }
        return true;
    }
}
