using UnityEngine;
using System.IO;

public class JsonLoginUtil : MonoBehaviour {
    string saveFile;
    void Awake() {
        saveFile = Application.persistentDataPath + "/gamedata.json";
    }
    public void SalvaLogin(LoginDTO login)
    {
        if (!File.Exists(saveFile))
        {
            File.Create(saveFile);
        }
        File.WriteAllText(saveFile, JsonUtility.ToJson(login));
    }

    public LoginDTO BuscaLogin()
    {
        return JsonUtility.FromJson<LoginDTO>(saveFile);
    }

}
