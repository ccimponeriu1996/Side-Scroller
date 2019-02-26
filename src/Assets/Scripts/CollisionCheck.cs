using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    protected BoxCollider2D bc;
    public LayerMask groundLayer;

    private float groundRaycastLength;
    private float wallRaycastLength;
    public enum WallDetected { both, left, right, none};

    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
        groundRaycastLength = (bc.bounds.size.y/2) + .2f;
        wallRaycastLength = (bc.bounds.size.x/2) +.015f;
    }

    //Ground Check method
    public bool GroundCheck()
    {
        RaycastHit2D ground = Physics2D.Raycast
            (transform.position,
            Vector2.down,
            groundRaycastLength,
            groundLayer);
        if (ground.collider != null)
        {
            return true;
        }
        return false;
    }

    //Wall Check Method
    public WallDetected WallCheck()
    {
        RaycastHit2D wallLeft = Physics2D.Raycast
            (transform.position,
            Vector2.left,
            wallRaycastLength,
            groundLayer);
        RaycastHit2D wallRight = Physics2D.Raycast
            (transform.position,
            Vector2.right,
            wallRaycastLength,
            groundLayer);
        //If touching both walls will return 0
        if (wallLeft.collider != null && wallRight.collider != null)
        {
            print("both");
            return WallDetected.both;
        }
        //If touching just the left wall
        if (wallLeft.collider != null)
        {
            print("left");
            return WallDetected.left;
        }
        //If touching just the right wall
        if (wallRight.collider != null)
        {
            print("right");
            return WallDetected.right;
        }
        //If touching no walls
        print("none");
        return WallDetected.none;
    }

    // Called once per physics update
    void FixedUpdate()
    {
        WallCheck();
    }
}
