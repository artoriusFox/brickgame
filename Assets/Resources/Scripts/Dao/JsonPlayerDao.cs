using UnityEngine;
using System.IO;
using System.Collections;
using System.Linq;
using System;
using Newtonsoft.Json;

public class JsonPlayerDao : MonoBehaviour
{
    string saveFile;
    public void iniciar()
    {
        saveFile = Application.persistentDataPath + "/players.json";
        if (!File.Exists(saveFile))
        {
            File.Create(saveFile);
        }
    }
    public void SalvaPlayerFase(PlayerSaveModel playerSaveModel) {
        SavesModel saves = BuscaTodosPlayes();

        /*
         * procura save se achar substitui e salva, return
         * Se nao achar Adiciona e salva
        */
       
        foreach (PlayerSaveModel psa in saves.Players) {
            if (psa.Email == playerSaveModel.Email) {
                if (psa.Fase >= playerSaveModel.Fase) {
                    return;
                }
                psa.Fase = playerSaveModel.Fase;
                File.WriteAllText(saveFile, JsonConvert.SerializeObject(saves));
                return;
            } 
        }
        
        saves.Players.Add(playerSaveModel);
        File.WriteAllText(saveFile, JsonConvert.SerializeObject(saves));

    }
    public PlayerSaveModel BuscaPlayer(string emailPlayer) {
        try
        {
            SavesModel saves = BuscaTodosPlayes();
            foreach (PlayerSaveModel psa in saves.Players)
            {
                Debug.Log(psa.Email+emailPlayer);
                if (psa.Email == emailPlayer)
                {
                    return psa;
                }
            }
            return new PlayerSaveModel();
        }
        catch (NullReferenceException e) {
            return new PlayerSaveModel();
        }
        
    }
    public SavesModel BuscaTodosPlayes() {
        var jsonString = File.ReadAllText(saveFile);
        SavesModel saves= JsonConvert.DeserializeObject<SavesModel>(jsonString);
        Debug.Log(saves.Players.Count);
        if (saves == null) {
            return new SavesModel();
        }
        return saves;
    }
}
