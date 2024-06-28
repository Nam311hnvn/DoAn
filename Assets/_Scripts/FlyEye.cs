using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyEye : MonoBehaviour
{
    public float flightSpeed = 4f;
    public float waypointReachDistance = 0.1f;
    public DetectionZone biteDetectionZone;
    public List<Transform> waypoints;


    Animator animator;
    Rigidbody2D rb;
    Damageable damageable;

    Transform nextWaypoint;
    int wayPointNum = 0;

    public bool _hasTarget = false;
    public bool HasTarget
    {
        get { return _hasTarget; }
        private set
        {
            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }

    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        damageable = GetComponent<Damageable>();
    }

    private void Start()
    {
        nextWaypoint = waypoints[wayPointNum];
    }

    // Update is called once per frame
    void Update()
    {
        HasTarget = biteDetectionZone.detectedColliders.Count > 0;
    }

    private void FixedUpdate()
    {
        if (damageable.IsAlive)
        {
            if (CanMove)
            {
                Flight();
            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
        else
        {
            rb.gravityScale = 2f;
        }
    }

    private void Flight()
    {
        Vector2 directionToWaypoint = (nextWaypoint.position - transform.position).normalized;//nornamlize sdung khi chi can huong cua vector va bo qua velocity

        //check xem da den waypoint chua
        float distance = Vector2.Distance(nextWaypoint.position, transform.position);

        rb.velocity = directionToWaypoint * flightSpeed;
        UpdateDirection();// chi khi nao bay moi ap dung update direction

        //xem co can doi waypoint ko
        if (distance <= waypointReachDistance)
        {
            wayPointNum++;

            if (wayPointNum >= waypoints.Count)
            {
                //loop ve way point ban dau
                wayPointNum = 0;
            }

            nextWaypoint = waypoints[wayPointNum];//update waypoint transform
        }
    }

    private void UpdateDirection()
    {
        Vector3 localScale = transform.localScale;

        if (transform.localScale.x > 0)
        {
            if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1 * localScale.x, localScale.y, localScale.z);
            }
        }
        else
        {
            if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(-1 * localScale.x, localScale.y, localScale.z);
            }
        }
    }
}
