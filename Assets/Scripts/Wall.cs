using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    private float dirx;
    [SerializeField] private GameObject player;
    private Rigidbody2D rb;

    private bool friction = false;

    [SerializeField] private float force = 250f;
    [SerializeField] private Vector2 vector;


    private void Start() 
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        if(friction == true)
        {
            rb.AddForce(vector * force);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        dirx = joystick.Horizontal;
        if(other.gameObject.name == "Player")
        {
            if (dirx != 0)
            {
                friction = true;
            }

            if (dirx == 0)
            {
                friction = false;
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.name == "Player")
        {
            friction = false;
        }
    }
}
