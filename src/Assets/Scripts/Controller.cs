using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    protected Rigidbody2D rb;
    protected BoxCollider2D bc;
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    private bool groundCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit)
        {
            print("true");
            return true;
        }
        else
        {
            print("false");
            return false;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    //Called once per physics update
    private void FixedUpdate()
    {
        groundCheck();
    }
}
