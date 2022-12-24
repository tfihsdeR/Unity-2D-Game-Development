using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int cherries;
    [SerializeField] private AudioSource collectCherries;

    [SerializeField] private Text cherriesText;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            collectCherries.Play();
            Destroy(collision.gameObject);
            cherries++;
            //Debug.Log("Cherries: " + cherries);

            cherriesText.text = "Cherries: " + cherries;

        }
    }

}
