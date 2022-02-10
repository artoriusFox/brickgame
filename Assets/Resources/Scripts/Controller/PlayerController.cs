using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private PlayerModel _playerModel;
    private Transform _playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=0f;
        _playerModel=GetComponent<PlayerModel>();
        _playerTransform=GetComponent<Transform>();
        populaNomeEmail();
    }

   
    // Update is called once per frame
    public void Move(float h)
    {
        if((_playerTransform.position.x<1.95f && h>0f) || (_playerTransform.position.x>-1.95f && h<0f) ){
            _playerTransform.Translate(h*_playerModel.Speed*Time.deltaTime,0f,0f);
        }

        if(_playerTransform.position.x<-1.95f){
            _playerTransform.Translate(0.05f*_playerModel.Speed*Time.deltaTime,0f,0f);
        }
        if(_playerTransform.position.x>1.95f){
            _playerTransform.Translate(-0.05f*_playerModel.Speed*Time.deltaTime,0f,0f);
        }

    }

    public void iniciaFase() {
        GameObject.Find("InitialUI").GetComponent<CanvasGroup>().alpha = 0f;
        GameObject.Find("InitialUI").GetComponent<CanvasGroup>().blocksRaycasts = false;
        Time.timeScale = 1f;
    }
    private void populaNomeEmail(){
        LoginController _loginController = new LoginController();
        _loginController.Awake();
        LoginDTO login = _loginController.BuscaLogin();

        _playerModel.PlayerName = login.Nome;
        _playerModel.PlayerEmail = login.Email;
        GameObject.Find("NameText").GetComponent<Text>().text = _playerModel.PlayerName;
        GameObject.Find("EmailText").GetComponent<Text>().text = _playerModel.PlayerEmail;
    }

}
