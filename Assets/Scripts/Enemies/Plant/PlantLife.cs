using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantLife : MonoBehaviour
{
    [SerializeField] private GameObject plant;

    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D boxCol;


    private void Awake() 
    {
        anim = plant.GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boxCol.enabled = false;
            plant.GetComponent<BoxCollider2D>().enabled = false;
            plant.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            anim.SetTrigger("Die");
            Invoke("Die", 2);
        }
    }


    public void Die()
    {
        Destroy(plant);
        //Destroy(rb);
        //Destroy(plant.GetComponent<Rigidbody2D>());
        //rb.Sleep();
        //plant.GetComponent<Rigidbody2D>().Sleep();
    }
}
