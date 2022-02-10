using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickModel : MonoBehaviour
{
    [SerializeField]
    private int _health;
    [SerializeField]
    private GameObject _effectSprite;

    public int Health { get => _health; set => _health = value; }

    public GameObject EffectSprite{ get => _effectSprite; set => _effectSprite = value; }
}
