using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private BallModel _ballModel;
    private Rigidbody2D _ballRigidBody;   
    // Start is called before the first frame update
    void Start()
    {
        _ballModel=GetComponent<BallModel>();
        _ballRigidBody=GetComponent<Rigidbody2D>();
        _ballRigidBody.velocity=_ballModel.Direction*_ballModel.Speed;
    }

    public void PerfectAngleReflect(Collision2D collision){
        AngleChange(Vector2.Reflect(_ballModel.Direction,collision.contacts[0].normal));
    }

    public Vector2 CalcBallAngleReflect(Collision2D collision){
        float playerPixels=120f;
        float unityScaleHalfPlayerPixels=playerPixels/2f/100f;
        float scaleFactorPut1to180Range=180f/playerPixels;

        float angleDegUnityScale=(collision.transform.position.x-
        transform.position.x+
        unityScaleHalfPlayerPixels)*scaleFactorPut1to180Range;
        float angleDeg=angleDegUnityScale*100f;
        float angleRad=angleDeg*Mathf.PI/180f;

        return new Vector2(Mathf.Cos(angleRad),Mathf.Sin(angleRad));
    }

    public void AngleChange(Vector2 direcao){
        _ballModel.Direction=direcao;
        _ballRigidBody.velocity=_ballModel.Direction*_ballModel.Speed;
    }
}
