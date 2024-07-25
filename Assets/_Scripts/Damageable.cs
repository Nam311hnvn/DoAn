using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour/*, IDataPersistence*/
{
    [SerializeField] private string id;
    /*
        [ContextMenu("Generate guid for id")]*/

    public DeadMenu deadMenuManager;
    public bool isPlayer = false;

    /*  private void GenerateGuid()
      {
          id = System.Guid.NewGuid().ToString();
      }*/


    GameData gameData;
    public UnityEvent<int, Vector2> damageableHit;//unity event dung de tao event trong script tren unity
    Animator animator;
    public UnityEvent<int, int> healthChanged;



    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private bool isInvincible = false;


    public float timeSinceHit = 0;
    public float invincibilityTime = 0.2f;


    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    [SerializeField] private int _health = 100;

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            healthChanged?.Invoke(_health, MaxHealth);

            if (_health <= 0)
            {
                IsAlive = false;
                if (isPlayer == true)
                {
                    deadMenuManager.GameOver();
                }
            }
        }
    }

    [SerializeField] private bool _isAlive = true;

    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("isAlive set" + value);
        }
    }

    public bool LockVelocity
    {
        get
        {
            return animator.GetBool(AnimationStrings.lockVelocity);
        }
        private set
        {
            animator.SetBool(AnimationStrings.lockVelocity, value);
        }
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Update()
    {
        if (isInvincible)
        {
            if (timeSinceHit > invincibilityTime)
            {
                //remove invincibility
                isInvincible = false;
                timeSinceHit = 0;
            }
            timeSinceHit += Time.deltaTime;//deltaTime la tgian giua cac frame
        }
    }
    public bool Hit(int damage, Vector2 knockback)
    {
        //danh dc
        if (IsAlive && !isInvincible)
        {
            Health -= damage;
            isInvincible = true;

            //thong bao cho cac component khac damageable danh trung de tien hanh xu ly knockback
            animator.SetTrigger(AnimationStrings.hitTrigger);
            LockVelocity = true;
            damageableHit?.Invoke(damage, knockback);//? de check event null hoac co du lieu
            CharacterEvents.characterDamaged.Invoke(gameObject, damage);//invoke de trigger event

            return true;
        }
        //ko danh dc
        return false;
    }

    public void Heal(int healthRestore)
    {
        if (IsAlive)
        {
            int maxHeal = Mathf.Max(MaxHealth - Health, 0);
            int actualHeal = Mathf.Min(maxHeal, healthRestore);
            Health += actualHeal;
            CharacterEvents.characterHealed.Invoke(gameObject, actualHeal);
        }
    }
}

