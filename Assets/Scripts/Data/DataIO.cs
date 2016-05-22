using UnityEngine;

public class DataIO {

    public DataIO() {
        Load();
    }
    ~DataIO() {
    }

    // Must Override!
    public virtual void Load() {
    }

    // Getter / Setter
    // Default Functions
    public void LoadFile(string filePath) {
        TextAsset _txtFile = (TextAsset)Resources.Load(filePath) as TextAsset;
        if (_txtFile == null) {
            Debug.LogError("LoadFile Fail : " + filePath);
            return;
        }

        string[] inputData = _txtFile.text.Split('\n');
        for (int i = 1; i < inputData.Length-1; i++) {
            string[] inputLine = inputData[i].Split(',');
            string keyValue = inputLine[0];
            if (ParseData(inputLine, i) == false) {
                Debug.LogError("Parsing fail : " + inputLine.ToString());
            }
        }
    }

    public bool ParseData(string[] inputLine, int lineCount) {
        if (VarifyKey(inputLine[0]) == false) {
            Debug.Log("VarifyKey fail : " + inputLine[0]);
            return false;
        }
        Parse(inputLine);
        return true;
    }

    public virtual void Parse(string[] inputData) {
    }

    public virtual bool VarifyKey(string keyValue) {

        return true;
    }

    void Save() {

    }
}
