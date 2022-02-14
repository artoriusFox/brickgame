using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class BallView : MonoBehaviour
{
    private BallController _ballController;
    private BallModel _ballModel;
    private Transform _ballTransform;
    private AudioSource _audioBall;
    private PlayerModel _playerModel;
    private bool _loseLife;
    private Scene _actualScene;
    void Start()
    {
        _loseLife=false;
        _ballController=GetComponent<BallController>();
        _ballModel=GetComponent<BallModel>();
        _ballTransform=GetComponent<Transform>();
        _audioBall=GetComponent<AudioSource>();
        _actualScene=SceneManager.GetActiveScene();

    }

    void Update(){
        if(_loseLife){
            if (Input.GetMouseButtonDown(0)){
                _ballModel.Speed=4f;
                _ballModel.Power=2f;
                _ballController.AngleChange(new Vector2(0.7071070f,0.7071070f));
                _loseLife=false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemy"){
            AudioClip _audioPlay=Resources.Load("Sounds/zapsplat_cartoon_pop_bubble_etc_007_77430") as AudioClip;
            _audioBall.clip=_audioPlay;
            _audioBall.Play();
            BrickView _brickView=collision.gameObject.GetComponent<BrickView>();
            _brickView.PerformTakeDamage(1);
        }

        if(collision.gameObject.tag=="Wall"){
            AudioClip _audioPlay=Resources.Load("Sounds/zapsplat_multimedia_game_sound_drop_metal_item_001_79289") as AudioClip;
            _audioBall.clip=_audioPlay;
            _audioBall.Play();
        }

        if(collision.gameObject.tag=="Lose"){
            PlayerModel _playerModel=GameObject.Find("Player").GetComponent<PlayerModel>();
            if(_playerModel.Life==0){
                GameObject.Find("GameOverUI").GetComponent<AudioSource>().Play();
                GameObject.Find("GameOverUI").GetComponent<CanvasGroup>().alpha=1;
                GameObject.Find("GameOverUI").GetComponent<CanvasGroup>().blocksRaycasts=true;
                _ballTransform.position=new Vector2(0.02f,-2.43f);
                Time.timeScale=0f;
            }else{
                AudioClip _audioPlay=Resources.Load("Sounds/zapsplat_multimedia_game_sound_short_high_pitched_buzzer_78377") as AudioClip;
                _audioBall.clip=_audioPlay;
                _audioBall.Play();
                _loseLife=true;
                _ballTransform.position=new Vector2(0.02f,-2.43f);
                _ballModel.Speed=0f;
                _ballModel.Power=0f;
                _playerModel.Life-=1;
                Text textLife=GameObject.Find("LifeNText").GetComponent<Text>();
                textLife.text=((int.Parse(textLife.text))-1).ToString();
            }
        }

        if(collision.gameObject.tag=="Player"){
            AudioClip _audioPlay=Resources.Load("Sounds/little_robot_sound_factory_Hit_03") as AudioClip;
            _audioBall.clip=_audioPlay;
            _audioBall.Play();
            _ballController.AngleChange(_ballController.CalcBallAngleReflect(collision)); 
        }else{
            _ballController.PerfectAngleReflect(collision);
        }
        
    }

    public void LoadSceneGameOver(){
        SceneManager.LoadScene(_actualScene.name,LoadSceneMode.Single);
    }

    public void LoadNextScene(int fase){
        SceneManager.LoadScene("Fase"+fase.ToString(),LoadSceneMode.Single);
        SalvaProgresso(fase);
    }

    private void SalvaProgresso(int fase)
    {
        JsonPlayerDao playerDao = new JsonPlayerDao();
        JsonLoginDao loginDao = new JsonLoginDao();
        playerDao.iniciar();
        loginDao.iniciar();

        playerDao.SalvaPlayerFase(new PlayerSaveModel(loginDao.BuscaEmail(), fase));
    }
}
