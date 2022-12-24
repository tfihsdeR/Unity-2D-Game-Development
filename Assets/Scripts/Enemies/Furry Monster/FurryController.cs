using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurryController : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;


    [Header("PATROL WAYPOINTS")]
    //Create patrol waypoints
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    [SerializeField] private float walkSpeed = 2f;


    [Header("OTHER INFORMATIONS")]
    [SerializeField] private GameObject furry;


    void Start()
    {
        sprite = furry.GetComponent<SpriteRenderer>();
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
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, furry.transform.position) < .5f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }            
        }
        
        furry.transform.position = Vector2.MoveTowards(furry.transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * walkSpeed);
        UpdateAnimation();
    }
}
