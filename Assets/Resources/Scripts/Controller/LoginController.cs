using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class LoginController : MonoBehaviour{
    string saveFile;
    public void SalvaEmailLoginJson(){
        string nome = GameObject.Find("NameSet").GetComponent<Text>().text;
        string email = GameObject.Find("EmailSet").GetComponent<Text>().text;
        if (validaEmail(email)) {
            LoginDTO login = new LoginDTO(nome,email);
            SalvaLogin(login);
            ChamarSelecaoFases();
        }
    
    }

    private void ChamarSelecaoFases()
    {
        SceneManager.LoadScene("LevelSelector", LoadSceneMode.Single);
    }

    private bool validaEmail(string email) {
        const string MatchEmailPattern =
            @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";
        if (Regex.IsMatch(email, MatchEmailPattern))
        {
            return true;
        }
        else
        {
            GameObject.Find("EmailSet").GetComponent<Text>().color = Color.red;
            return false;
        }
    }
  
    void Awake()
    {
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
        var jsonString = File.ReadAllText(saveFile);
        return JsonUtility.FromJson<LoginDTO>(jsonString);
    }

}
