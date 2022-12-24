using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fan : MonoBehaviour
{
    [SerializeField] private float windStrength = 500f;
    [SerializeField] private Vector2 windDirection;

    private bool inWindZone;

    [SerializeField] private GameObject player;
    private Rigidbody2D rb;

    private void Start() 
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate() 
    {
        if (inWindZone)
        {
            rb.AddForce(windDirection * windStrength);
        }
    }

    private void OnTriggerEnter2D(Collider2D collission) 
    {
        if (collission.gameObject.name == "Player")
        {
            inWindZone = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject.name == "Player")
        {
            inWindZone = false;
        }
    }
}
