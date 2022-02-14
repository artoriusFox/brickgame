using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrickController : MonoBehaviour
{
    private BrickModel _brickModel;
    private Transform _brickTransform;
    // Start is called before the first frame update
    void Start()
    {
        _brickModel=GetComponent<BrickModel>();
        _brickTransform=GetComponent<Transform>();
    }

    public void TakeDamage(int damage)
    {
        _brickModel.Health=_brickModel.Health-damage;
        if(_brickModel.Health==0){
            Text textScore = GameObject.Find("ScoreNText").GetComponent<Text>();
            Text textBricks=GameObject.Find("NumberBricksText").GetComponent<Text>();
            textBricks.text=((int.Parse(textBricks.text))-1).ToString();
            textScore.text = ((int.Parse(textScore.text) + _brickModel.Points)).ToString();

            if (textBricks.text=="0")
            {
                GameObject.Find("WinUI").GetComponent<CanvasGroup>().alpha=1;
                GameObject.Find("WinUI").GetComponent<AudioSource>().Play();
                GameObject.Find("WinUI").GetComponent<CanvasGroup>().blocksRaycasts=true;
                Time.timeScale=0f;
            }else{
                Instantiate(_brickModel.EffectSprite, _brickTransform.position, Quaternion.identity);
                GameObject.Find("Explosion(Clone)").GetComponent<AudioSource>().Play();
                Destroy(gameObject);
                GameObject[] _explosions=GameObject.FindGameObjectsWithTag("Explosion");
                foreach (GameObject _explosionPrefab in _explosions)
                {
                    Destroy(_explosionPrefab,0.5f);
                }
            }
        }
    }
}
