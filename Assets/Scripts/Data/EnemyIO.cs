using UnityEngine;
using System;
using System.Collections.Generic;

public class EnemyIO :DataIO {

    private static EnemyIO instance;
    public static EnemyIO getInstance {
        get {
            if (instance == null) {
                instance = new EnemyIO();
            }
            return instance;
        }
    }

    string _baseFileName = "EnemyList.cvs";
    Dictionary<int, EnemyStruct> enemyList = new Dictionary<int, EnemyStruct>();

    public EnemyIO() {
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
        EnemyStruct tempData;
        tempData.index = Convert.ToInt32(inputData[count++]);
        tempData.hp = Convert.ToInt32(inputData[count++]);
        tempData.speed = Convert.ToInt32(inputData[count++]);
        tempData.dropCandy = Convert.ToInt32(inputData[count++]);
        enemyList.Add(tempData.index, tempData);
    }

    public bool GetEnemyData(EnemyType index, out EnemyStruct enemyData) {
        if (enemyList.TryGetValue((int)index, out enemyData) == false) {
            Debug.LogWarning("not existed Data: " + index.ToString());
            return false;
        }
        return true;
    }
}
