using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    [SerializeField] private GameObject wall;
    [SerializeField] private GameObject player;
    private Rigidbody2D rb;
    private Collider2D coll;
    private Collider2D wallColl;

    private Physics2D Physics2D;

    public bool doubleJump;

    private float dirx;
    [SerializeField] Joystick joystick;

    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private AudioSource jumpSoundEffect;

    [SerializeField] private float jumpForce = 14f;


    public void Start() 
    {
        rb = player.GetComponent<Rigidbody2D>();
        coll = player.GetComponent<Collider2D>();
        wallColl = wall.GetComponent<Collider2D>();
    }

    public void jumpButton()
    {
        dirx = joystick.Horizontal;
        if (IsGrounded() || (wallCheck() && dirx != 0))
        {
            rb.velocity = Vector2.up * jumpForce;
            jumpSoundEffect.Play();
            doubleJump = true;
            }
        else if (doubleJump == true )
        {
            doubleJump = false;
            rb.velocity = Vector2.up * jumpForce;
            jumpSoundEffect.Play();
        }
    }

        
    //karakter yere değiyor mu?
    public bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }

    private bool wallCheck()
    {
        return (Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.left, 0.1f, wallLayer) 
            || Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.right, 0.1f, wallLayer));
    }
}
