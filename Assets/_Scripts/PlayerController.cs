using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections),typeof(Damageable))]//class playercontroller duoc them vao thi tu dong them 2 component trong typeof
public class PlayerController : MonoBehaviour, IDataPersistence
{

    public float walkSpeed = 5f;
    public float runSpeed = 10f;
    public float airSpeed = 3.0f;
    public float jumpImpulse = 10f;
    Vector2 moveInput;

    TouchingDirections touchingDirections;
    Rigidbody2D rb;
    Animator animator;
    Damageable damageable;

    [SerializeField] private bool _isMoving = false;//hien bien tren inspector
    [SerializeField] private bool _isRunning = false;
    [SerializeField] private bool _isFacingRight = true;


    //toc chay hien tai de phan biet chay va di bo
    public float CurrentMoveSpeed
    {
        get
        {
            if (CanMove)
            {

                if (IsMoving && !touchingDirections.IsOnWall)
                {
                    if (touchingDirections.IsGrounded)
                    {

                        if (_isRunning)
                        {
                            return runSpeed;
                        }
                        else
                        {
                            return walkSpeed;
                        }
                    }
                    else
                    {
                        return airSpeed;
                    }
                }
                else
                {

                    return 0;// trang thai dung yen thi v=0
                }
            }
            else
            {
                return 0;
            }
        }
    }
    //lay va dat trang thai isMoving
    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;
            animator.SetBool(AnimationStrings.isMoving, value);
        }
    }
    //lay va dat trang thai isRunning
    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        private set
        {
            _isRunning = value;
            animator.SetBool(AnimationStrings.isRunning, value);
        }
    }


    public bool IsFacingRight
    {
        get
        {
            return _isFacingRight;
        }
        private set
        {   //value moi thi moi lat 
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);//lat player 180 do
            }
            _isFacingRight = value;
        }
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    public bool IsAlive
    {
        get
        {
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }


    //Goi khi khoi dong
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        damageable = GetComponent<Damageable>();//Damageable;
    }

    //FixedUpdate xu ly cac chuc nang lquan den vat ly
    private void FixedUpdate()
    {
        if (!damageable.LockVelocity)//damageable
        {
            rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);
        }

        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);

    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        if (IsAlive)
        {

            IsMoving = moveInput != Vector2.zero;

            SetFacingDirection(moveInput);
        }
        else
        {
            IsMoving = false;
        }
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !IsFacingRight)// quay phai
        {
            IsFacingRight = true;
        }
        else if (moveInput.x < 0 && IsFacingRight)//quay trai
        {
            IsFacingRight = false;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
        }
        else if (context.canceled)
        {
            IsRunning = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {

        if (context.started && touchingDirections.IsGrounded && CanMove)
        {
            animator.SetTrigger(AnimationStrings.jumpTrigger);
            rb.velocity = new Vector2(airSpeed, jumpImpulse);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.attackTrigger);
        }
    }

    public void OnRangedAttack(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            animator.SetTrigger(AnimationStrings.rangedAttackTrigger);
        }
    }

    public void OnHit(int damage, Vector2 knockback)
    {
        
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }

    public void LoadData(GameData data)
    {
      /* this.transform.position = data.playerPosition;*/
    }

    public void SaveData(ref GameData data)
    {
        /*data.playerPosition = this.transform.position;*/
    }
}
