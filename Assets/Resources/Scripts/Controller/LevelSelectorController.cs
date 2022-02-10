using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectorController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
