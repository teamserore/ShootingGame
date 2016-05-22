using UnityEngine;
using System;
using System.Collections.Generic;

public class DefSettingIO :DataIO {

    private static DefSettingIO instance;
    public static DefSettingIO getInstance {
        get {
            if (instance == null) {
                instance = new DefSettingIO();
            }
            return instance;
        }
    }

    string _baseFileName = "DefaultSetting";
    Dictionary<string, int> defSettingList = new Dictionary<string, int>();

    public DefSettingIO() {
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
        string key = Convert.ToString(inputData[count++]);
        int data = Convert.ToInt32(inputData[count++]);
        defSettingList.Add(key, data);
    }

    public bool GetData(string key, out int data) {
        if (defSettingList.TryGetValue(key, out data) == false) {
            Debug.LogWarning("not existed Data: " + key.ToString());
            return false;
        }
        return true;
    }
}
