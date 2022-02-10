using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField]
    private int _life;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private string _playerName;
    [SerializeField]
    private string _playerEmail;

    public float Speed { get => _speed; set => _speed = value; }

    public int Life { get => _life; set => _life = value; }

    public string PlayerName  { get => _playerName; set => _playerName = value; }

    public string PlayerEmail  { get => _playerEmail; set => _playerEmail = value; }

}
