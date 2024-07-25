using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameDataManager : MonoBehaviour
{

    public GameData gameData = new GameData();
    Damageable damageable;
    Attack meleeAttack;
    PlayerController playerStat;
    

    private void Awake()
    {
        damageable = GetComponent<Damageable>();
        meleeAttack = GetComponentInChildren<Attack>();
        playerStat = GetComponent<PlayerController>();       
        LoadData();
    }
    public void LoadData()
    {
        damageable.MaxHealth = gameData.maxHealth;

        damageable.Health = gameData.health;

        playerStat.walkSpeed = gameData.walkSpeed;

        playerStat.runSpeed = gameData.runSpeed;

        playerStat.airSpeed = gameData.airSpeed;

        playerStat.jumpImpulse = gameData.jumpImpulse;

        meleeAttack.attackDamage = gameData.attackDamage;

        meleeAttack.knockback = gameData.meleeKnockback;
    }

    public void SaveData()
    {
        gameData.maxHealth = damageable.MaxHealth;

        gameData.health = damageable.Health;

        gameData.walkSpeed = playerStat.walkSpeed;

        gameData.runSpeed = playerStat.runSpeed;

        gameData.airSpeed = playerStat.airSpeed;

        gameData.jumpImpulse = playerStat.jumpImpulse;

        gameData.attackDamage = meleeAttack.attackDamage;

        gameData.meleeKnockback = meleeAttack.knockback;      
    }
    
}
