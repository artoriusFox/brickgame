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

    public void SetNameAndEmail(){
        const string MatchEmailPattern = 
			@"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
            + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
            + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?
				[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
            + @"([a-zA-Z0-9]+[\w-]+\.)+[a-zA-Z]{1}[a-zA-Z0-9-]{1,23})$";
        _playerModel.PlayerName=GameObject.Find("NameSet").GetComponent<Text>().text;
        _playerModel.PlayerEmail=GameObject.Find("EmailSet").GetComponent<Text>().text;
        if(Regex.IsMatch(_playerModel.PlayerEmail, MatchEmailPattern)){
            GameObject.Find("NameText").GetComponent<Text>().text=_playerModel.PlayerName;
            GameObject.Find("EmailText").GetComponent<Text>().text=_playerModel.PlayerEmail;
            GameObject.Find("InitialUI").GetComponent<CanvasGroup>().alpha=0f;
            GameObject.Find("InitialUI").GetComponent<CanvasGroup>().blocksRaycasts=false;
            Time.timeScale=1f;
        }else{ 
            GameObject.Find("EmailSet").GetComponent<Text>().color=Color.red;
        }  
    }
}
