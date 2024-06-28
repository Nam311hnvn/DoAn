using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BlessingButton : MonoBehaviour
{
    [SerializeField] public Blessings Blessing_script;
    public TMP_Text blessingText;
    [SerializeField] DataPersistencemanager data;

    

    //khai bao ko sdung script blessing trong project
    //chi keo dc obj co chua script vao public
    //khi keo blessing trong project
    public void Blessing()
    {
        string Blessing_chosen = blessingText.text;

        Blessing_script.BlessingChosen(Blessing_chosen);
        Blessing_script.ButtonSet();
        data.SaveGame();      
    }

}
