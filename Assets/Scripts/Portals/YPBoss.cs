using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YPBoss : MonoBehaviour
{
    [SerializeField] private GameObject player;


    private void Start() 
    {
        Invoke("Spawn", 3);
        Invoke("Hide", 4);
    }


    private void Spawn()
    {
        player.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
