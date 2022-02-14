using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSelectorController : MonoBehaviour
{
    LoginDTO login;
    PlayerSaveModel plauerSaveModel;
    JsonLoginDao jsonLoginDao = new JsonLoginDao();
    JsonPlayerDao jsonPlayerDao = new JsonPlayerDao();

    void Start() {
     
    }
    private void Awake()
    {
        jsonLoginDao.iniciar();
        jsonPlayerDao.iniciar();
        login = jsonLoginDao.BuscaLogin();
        plauerSaveModel = GetPlayerSaveModel();
        populaPermissoes();
    }

    private void populaPermissoes()
    {
        for (int i = 1; i <= 4; i++) {
            if (i > plauerSaveModel.Fase) {
                GameObject.Find("ButtonLevel" + i.ToString()).GetComponent<Button>().interactable = false;
            }
        }
    }

    private PlayerSaveModel GetPlayerSaveModel()
    {
        PlayerSaveModel player = jsonPlayerDao.BuscaPlayer(login.Email);
        if (String.IsNullOrEmpty(player.Email)) {
            player = new PlayerSaveModel(login.Email, 1);
            jsonPlayerDao.SalvaPlayerFase(player);
        }
        return player;
    }

    public void AbrirFase1() {
        SceneManager.LoadScene("Fase1", LoadSceneMode.Single);
    }
    public void AbrirFase2() {
        SceneManager.LoadScene("Fase2", LoadSceneMode.Single);
    }
    public void AbrirFase3() {
        SceneManager.LoadScene("Fase3", LoadSceneMode.Single);
    }
    public void AbrirFase4() {
        SceneManager.LoadScene("Fase1", LoadSceneMode.Single);
    }

    private void VerificaUsuarioNivelHabilitado(int level){ 

        
    }
}
