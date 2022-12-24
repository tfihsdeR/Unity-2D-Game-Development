using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurryLife : MonoBehaviour
{
    [SerializeField] private GameObject furry;
    [SerializeField] private GameObject parentFurry;    

    private Animator anim;
    private Rigidbody2D rb;
    private BoxCollider2D boxCol;


    private void Awake() 
    {
        anim = furry.GetComponent<Animator>();
        rb = furry.GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
    }


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            boxCol.enabled = false;
            furry.GetComponent<CapsuleCollider2D>().enabled = false;
            furry.GetComponent<FurryController>().enabled = false;
            anim.SetTrigger("Die");
            Invoke("Die", 2);
        }
    }


    public void Die()
    {
        furry.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        Destroy(parentFurry);
        //Destroy(rb);
        //Destroy(furry.GetComponent<Rigidbody2D>());
        //rb.Sleep();
        //furry.GetComponent<Rigidbody2D>().Sleep();
    }
}
