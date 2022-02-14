using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavesModel {
    private List<PlayerSaveModel> players = new List<PlayerSaveModel>();

    public List<PlayerSaveModel> Players { get => players; set => players = value; }
}
