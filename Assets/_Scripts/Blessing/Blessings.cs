using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Blessings : MonoBehaviour
{
    [SerializeField] GameDataManager gameDataManager;
    /*Damageable damageable;
    Attack meleeAttack;
    PlayerController playerStat;*/

    //define list with blessing

    Blessing[] _Blessing = new Blessing[]
    {

        new Blessing{Name = "Max Health",Description ="Increase X Max health ",Rarity ="rare",Increase=20},
        new Blessing{Name = "Health",Description ="Increase X health ",Rarity ="common",Increase=40},
        new Blessing{Name = "Walk Speed",Description ="Increase walk speed by X",Rarity ="common",Increase=1},
        new Blessing{Name = "Run Speed",Description ="Increase run speed by X",Rarity ="rare",Increase=2},
        new Blessing{Name = "Air Speed",Description ="Increase air speed by X",Rarity ="common",Increase=1},
        new Blessing{Name = "Jump Impulse",Description ="Increase jump impulse by X",Rarity ="common",Increase=1},
        new Blessing{Name = "Attack Damage",Description ="Increase atk dmg by X",Rarity ="rare",Increase=10},
        new Blessing{Name = "Melee Knockback",Description ="Increase knockback by X",Rarity ="epic",Increase=1}
    };

    
    [SerializeField] private Button Blessing_button1;
    [SerializeField] private Button Blessing_button2;
    [SerializeField] private Button Blessing_button3;

    [SerializeField] private TMP_Text Blessing_DescriptionText1;
    [SerializeField] private TMP_Text Blessing_DescriptionText2;
    [SerializeField] private TMP_Text Blessing_DescriptionText3;

    /*private void Awake()
    {
        *//*gameData = GetComponent<GameData>();*//*
        damageable = GetComponent<Damageable>();
        meleeAttack = GetComponentInChildren<Attack>();
        playerStat = GetComponent<PlayerController>();        
    }*/
    private void Start()
    {
        ButtonSet();
    }

    public void ButtonSet()
    {
        //Choosing blessing from upgrade array
        List<int> availableBlessing = new List<int>();
        for (int i = 0; i < _Blessing.Length; i++)
        {
            availableBlessing.Add(i);
        }

        ShuffleList(availableBlessing);
        Blessing Blessing_1 = _Blessing[availableBlessing[0]];
        Blessing Blessing_2 = _Blessing[availableBlessing[1]];
        Blessing Blessing_3 = _Blessing[availableBlessing[2]];


        // Setting text
        Blessing_button1.transform.GetChild(0).GetComponent<TMP_Text>().text = Blessing_1.Name;
        Blessing_button2.transform.GetChild(0).GetComponent<TMP_Text>().text = Blessing_2.Name;
        Blessing_button3.transform.GetChild(0).GetComponent<TMP_Text>().text = Blessing_3.Name;



        // Replacing the X with increase value
        Blessing_DescriptionText1.text = Blessing_1.Description.Replace("X", Blessing_1.Increase.ToString());
        Blessing_DescriptionText2.text = Blessing_2.Description.Replace("X", Blessing_2.Increase.ToString());
        Blessing_DescriptionText3.text = Blessing_3.Description.Replace("X", Blessing_3.Increase.ToString());

        // Setting color of the buttons
        Dictionary<string, Color> rarityColors = new Dictionary<string, Color>();
        rarityColors.Add("common", new Color(1, 1, 1, 1));
        rarityColors.Add("rare", new Color(0.5f, 1f, 0.5f, 1));
        rarityColors.Add("epic", new Color(0.75f, 0.25f, 0.75f, 1));

        Blessing_button1.GetComponent<Image>().color = rarityColors[Blessing_1.Rarity];
        Blessing_button2.GetComponent<Image>().color = rarityColors[Blessing_2.Rarity];
        Blessing_button3.GetComponent<Image>().color = rarityColors[Blessing_3.Rarity];

        /*Blessing_button1.GetComponent<BlessingButton>().Blessing_script = Blessing_1;*/

    }

    //Blessing
    public void BlessingChosen(string Blessing_chosen)
    {
        gameDataManager.SaveData();
        if (Blessing_chosen == "Max Health")
        {
            //MaxHealth += increase
            gameDataManager.gameData.maxHealth += 20;
           
        }
        else if (Blessing_chosen == "Health")
        {
            gameDataManager.gameData.health += 40;

            Debug.Log("Health");
        }
        else if (Blessing_chosen == "Walk Speed")
        {

            gameDataManager.gameData.walkSpeed += 1;
            Debug.Log("Walk Speed");
        }
        else if (Blessing_chosen == "Run Speed")
        {
            gameDataManager.gameData.runSpeed += 1;
            Debug.Log("Run Speed");
        }
        else if (Blessing_chosen == "Air Speed")
        {
            gameDataManager.gameData.airSpeed += 1;
            Debug.Log("Air Speed");
        }
        else if (Blessing_chosen == "Jump Impulse")
        {
            gameDataManager.gameData.jumpImpulse += 1;
            Debug.Log("Jump Impulse");
        }
        else if (Blessing_chosen == "Attack damage")
        {
            gameDataManager.gameData.attackDamage += 10;
            Debug.Log("Attack Damage");
        }
        else if (Blessing_chosen == "Melee Knockback")
        {
            gameDataManager.gameData.meleeKnockback += new Vector2(1, 0);
            Debug.Log("Melee Knockback");
        }       
        gameDataManager.LoadData();
    }

    // SHUFFLE LIST
    public void ShuffleList(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            int randomIndex = Random.Range(i, list.Count);
            int temp = list[i];
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public class Blessing
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Rarity { get; set; }
        public float Increase { get; set; }
    }

    
}

