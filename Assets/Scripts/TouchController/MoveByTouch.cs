using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveByTouch : MonoBehaviour
{
    [SerializeField] GameObject player;

    [SerializeField] private Rigidbody2D rb;
    private Collider2D coll;


    private SpriteRenderer sprite;
    private Animator anim;

    public Joystick joystick;
    [SerializeField] private float moveSpeed = 7f;
    //[SerializeField] private float slideFactor = 0.2f;
    public float dirx = 0f;
    [SerializeField] private LayerMask wallLayer;

    JumpButton jumpButton;
    [SerializeField] GameObject jumpButtonObject;
    private bool doubleJump = true;

    public enum MovementState {idle, running, jumping, falling, wallSlide, doubleJumping}


    void Start() 
    {
        
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();    

        coll = GetComponent<Collider2D>();
        hidePlayer();
        
    }

    private void OnEnable() 
    {
        Invoke("spawnPlayer", 3f);
    }

    void Update() 
    
    {
        dirx = joystick.Horizontal;
        rb.gravityScale = 3f;
        rb.velocity = new Vector2(dirx * moveSpeed, rb.velocity.y);
        UpdateAnimationUpdate();
    }


    private void UpdateAnimationUpdate()
    {

        MovementState state;

        jumpButton = jumpButtonObject.GetComponent<JumpButton>();
        doubleJump = jumpButton.doubleJump;

        //Koşu
        if (dirx >0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }

        else if (dirx < 0)
        {
            state = MovementState.running;
            sprite.flipX = true;

        }

        //Sabit duruş
        else
        {
            state = MovementState.idle;
        }

        //Sıçrama - atlama
        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;

            //Double Jump
            if (!doubleJump)
            {
                state = MovementState.doubleJumping;
                doubleJump = true;
            }
        }

        //Düşüş
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        //Wall Sliding
        if(wallCheck() && dirx != 0)
        {
            state = MovementState.wallSlide;
        }

        anim.SetInteger("state", (int)(state));

    }

    private bool wallCheck()
    {
        return (Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.left, 0.1f, wallLayer) 
            || Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.right, 0.1f, wallLayer));
    }

    private IEnumerator wait()
    {
        yield return new WaitForSeconds(2);
    }

    private void spawnPlayer()
    {
        player.SetActive(true);
    }

    private void hidePlayer()
    {
        player.SetActive(false);
    }
}