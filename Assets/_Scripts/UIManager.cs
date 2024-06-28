using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class UIManager : MonoBehaviour
{
    public GameObject damageTextPrefab;
    public GameObject healthTextPrefab;

    public Canvas gameCanvas;

    private void Awake()
    {       
        CharacterEvents.characterDamaged+=CharacterTookDamage;
        CharacterEvents.characterHealed += CharacterHealed;
    }

    private void OnEnable()
    {
        
        CharacterEvents.characterDamaged += CharacterTookDamage;
        CharacterEvents.characterHealed+=CharacterHealed;
    }

    private void OnDisable()
    {
        CharacterEvents.characterDamaged -= CharacterTookDamage;
        CharacterEvents.characterHealed -= CharacterHealed;
    }

    public void CharacterTookDamage(GameObject character, int damageReceived)
    {
        gameCanvas = FindObjectOfType<Canvas>();
        //Create text at character hit
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);// lay vi tri cua world character va bien thanh point tren canvas   
        
        TMP_Text tmpText = Instantiate(damageTextPrefab,spawnPosition,Quaternion.identity,gameCanvas.transform).GetComponent<TMP_Text>();

        tmpText.text = damageReceived.ToString();
    }

    public void CharacterHealed(GameObject character, int healthRestored)
    {
        gameCanvas = FindObjectOfType<Canvas>();
        Vector3 spawnPosition = Camera.main.WorldToScreenPoint(character.transform.position);// lay vi tri cua world character va bien thanh point tren canvas   
        
        TMP_Text tmpText = Instantiate(healthTextPrefab, spawnPosition, Quaternion.identity,gameCanvas.transform).GetComponent<TMP_Text>();
        
        tmpText.text = healthRestored.ToString();
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
