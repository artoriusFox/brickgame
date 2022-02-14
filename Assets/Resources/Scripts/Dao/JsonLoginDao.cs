using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class JsonLoginDao : MonoBehaviour {
    string saveFile;
    public void iniciar() {
        saveFile = Application.persistentDataPath + "/login.json";
        if (!File.Exists(saveFile))
        {
            File.Create(saveFile);
        }
    }
    public void SalvaLogin(LoginDTO login)
    {
        File.WriteAllText(saveFile, JsonConvert.SerializeObject(login));
    }

    public LoginDTO BuscaLogin()
    {
        var jsonString = File.ReadAllText(saveFile);
        return JsonConvert.DeserializeObject<LoginDTO>(jsonString);
    }

    public string BuscaEmail() {
        return BuscaLogin().Email;
    }
}
