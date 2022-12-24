using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPExtraScript : MonoBehaviour
{
    [SerializeField] private GameObject nextPortal;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            nextPortal.SetActive(true);
        }
    }
}
