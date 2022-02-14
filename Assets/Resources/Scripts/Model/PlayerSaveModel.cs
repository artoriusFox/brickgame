using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSaveModel {
    private string email;
    private int fase;

    public PlayerSaveModel()
    {
    }

    public PlayerSaveModel(string email, int fase)
    {
        this.email = email;
        this.fase = fase;
    }

    public int Fase { get => fase; set => fase = value; }
    public string Email { get => email; set => email = value; }
}
