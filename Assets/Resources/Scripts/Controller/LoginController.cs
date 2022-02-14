using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class LoginController : MonoBehaviour{
    JsonLoginDao _jsonLoginDao = new JsonLoginDao();
    public void SalvaEmailLoginJson(){
        string nome = GameObject.Find("NameSet").GetComponent<Text>().text;
        string email = GameObject.Find("EmailSet").GetComponent<Text>().text;
        if (validaEmail(email)) {
            LoginDTO login = new LoginDTO(nome,email);
            _jsonLoginDao.SalvaLogin(login);
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
  
    public void Awake()
    {
        _jsonLoginDao.iniciar();
    }

    public LoginDTO BuscaLogin()
    {
        return _jsonLoginDao.BuscaLogin();
    }

}
