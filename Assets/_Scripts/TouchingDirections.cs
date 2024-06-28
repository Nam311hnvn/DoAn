using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    public ContactFilter2D castFilter;// check xem o tren mat dat hay tuong
    public float groundDistance = 0.05f;
    public float wallDistance = 0.05f;
    public float ceilingDistance = 0.05f;

    private Vector2 WallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    CapsuleCollider2D capsuleCol;
    Animator animator;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];//??
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];

    //ground
    [SerializeField] private bool _isGrounded ;
    public bool IsGrounded { get
        {
            return _isGrounded;
        } private set
        {
            _isGrounded = value;
            animator.SetBool(AnimationStrings.isGrounded, value);
        } }
    //wall
    [SerializeField] private bool _isOnWall;
    public bool IsOnWall
    {
        get
        {
            return _isOnWall;
        }
        private set
        {
            _isOnWall = value;
            animator.SetBool(AnimationStrings.isOnWall, value);
        }
    }
    //ceiling
    [SerializeField] private bool _isOnCeiling;
    

    public bool IsOnCeiling
    {
        get
        {
            return _isOnCeiling;
        }
        private set
        {
            _isOnCeiling = value;
            animator.SetBool(AnimationStrings.isOnCeiling, value);
        }
    }

    private void Awake()
    {
        capsuleCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    // FixedUpdate thuong dung de goi func lien quan den vat ly nhu movement, collision
    void FixedUpdate()
    {
        //cast chua du lieu trong groundhit array va tra ve int la gtri collision cast
        IsGrounded = capsuleCol.Cast(Vector2.down, castFilter, groundHits, groundDistance) > 0;

        IsOnWall = capsuleCol.Cast(WallCheckDirection,castFilter, wallHits, wallDistance) >0;

        IsOnCeiling = capsuleCol.Cast(WallCheckDirection, castFilter, ceilingHits, ceilingDistance) > 0;
    }

}
