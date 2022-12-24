using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;


    [Header("PATROL WAYPOINTS")]
    //Create patrol waypoints
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float walkSpeed = 2f;


    [Header("OTHER INFORMATIONS")]
    //jump info
    [SerializeField] private float jumpForce = 8f;


    //Animation states
    private enum movementState {idle, rise, fall}


    //Ground Check
    [SerializeField] private LayerMask groundLayer;


    [SerializeField] private GameObject player;
    [SerializeField] private GameObject slime;

    [Header("PLAYER DETECTION")]
    private bool playerDetected = false;



    void Start()
    {
        rb = slime.GetComponent<Rigidbody2D>();
        coll = slime.GetComponent<Collider2D>();
        sprite = slime.GetComponent<SpriteRenderer>();
        anim = slime.GetComponent<Animator>();
    }

    private void FixedUpdate() 
    {
        if(!playerDetected)
        {
            patrolling();
        }

        UpdateAnimation();
    }


    private void UpdateAnimation()
    {   
        movementState state = 0;

        if (currentWaypointIndex == 0)
        {
            sprite.flipX = false;
            state = movementState.idle;
        }
        else if (currentWaypointIndex == 1)
        {
            sprite.flipX = true;
            state = movementState.idle;
        }


        if (rb.velocity.y > .1f)
        {
            state = movementState.rise;
        }

        //Falling
        else if (rb.velocity.y < -0.1)
        {
            state = movementState.fall;
        }


        anim.SetInteger("State", (int)(state));
    }


    private void patrolling()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, slime.transform.position) < .5f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }            
        }
        
        slime.transform.position = Vector2.MoveTowards(slime.transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * walkSpeed);
        UpdateAnimation();
    }


    private void OnTriggerStay2D(Collider2D collision) 
    {
        if (collision.gameObject.tag == "Player" && onGround())
        {
            playerDetected = true;
            Invoke("attack", 1f);
            //InvokeRepeating("attack", 0.4f, 0.5f);
        }
    }


    private bool onGround()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, groundLayer);
    }


    private void attack()
    {
        float distanceToPlayer = player.transform.position.x - slime.transform.position.x;
        //rb.AddForce(new Vector2(distanceToPlayer,jumpForce),ForceMode2D.Impulse);
        rb.velocity = new Vector2(distanceToPlayer, jumpForce);
    }

    private IEnumerator waitAndAttack()
    {
        yield return new WaitForSecondsRealtime(1f);
    }
}
