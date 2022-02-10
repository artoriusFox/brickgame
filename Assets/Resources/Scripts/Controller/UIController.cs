using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    private GameObject _restartPanel;
    private GameObject _ball;
    void Start()
    {    
        _ball=GameObject.Find("Ball");
        _restartPanel=GameObject.Find("RestartPanel");
    }

    public void RestartAll(){
        Time.timeScale=0f;
        _restartPanel.GetComponent<CanvasGroup>().alpha=1f;
        _restartPanel.GetComponent<CanvasGroup>().blocksRaycasts=true;
    }

    public void YesButtonPressed(){
        SceneManager.LoadScene("InitialFase",LoadSceneMode.Single);
    }

    public void NoButtonPressed(){
        Time.timeScale=1f;
        _restartPanel.GetComponent<CanvasGroup>().alpha=0f;
        _restartPanel.GetComponent<CanvasGroup>().blocksRaycasts=false;
    }
    
    public void BallReset(){
        if(_ball.GetComponent<Rigidbody2D>().IsSleeping()){
            _ball.GetComponent<Transform>().position=new Vector2(0.02f,-2.43f);
            _ball.GetComponent<BallController>().AngleChange(new Vector2(0.7071070f,0.7071070f));
        }
    }
}
