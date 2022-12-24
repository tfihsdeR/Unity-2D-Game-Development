using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBS : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private SpriteRenderer sprite;


    [Header("PATROL WAYPOINTS")]
    //Create patrol waypoints
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float walkSpeed = 2f;


    [Header("OTHER INFORMATIONS")]
    [SerializeField] private GameObject slime;


    void Start()
    {
        sprite = slime.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate() 
    {
        patrolling();
        
        UpdateAnimation();
    }


    private void UpdateAnimation()
    {   
        if (currentWaypointIndex == 0)
        {
            sprite.flipX = false;
        }
        else if (currentWaypointIndex == 1)
        {
            sprite.flipX = true;
        }
    }


    private void patrolling()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, slime.transform.position) < .7f)
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

}
