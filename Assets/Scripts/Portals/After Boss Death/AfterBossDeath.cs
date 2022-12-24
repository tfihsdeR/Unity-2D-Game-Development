using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterBossDeath : MonoBehaviour
{
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject player;

    // Get the Camera Controller Script
    [SerializeField] private GameObject mainCam;
    private CameraController cameraController;
    
    [SerializeField] private GameObject[] Portals;

    private float timer;
    private int currentIndex = 1;


    private void Awake() 
    {
        cameraController = mainCam.GetComponent<CameraController>();
    }


    private void Update() 
    {
        if (boss == null)
        {
            if (currentIndex == 1)
                SpawnPortals();

            timer += Time.deltaTime;

            if (timer > 0.5f && currentIndex == 1)
            {
                // Move to the first portal into the boss cave
                cameraController.currentIndex++;
                currentIndex++;
            }            
            else if (timer > 1.5f && currentIndex == 2)
            {
                // move to the second portal
                cameraController.currentIndex++;
                currentIndex++;
            }
            else if (timer > 3f && currentIndex == 3)
            {
                // Return to the player position
                cameraController.currentIndex = 0;
                player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                currentIndex = 0;
            }

            cameraController.orthSize = 5;
        }
    }

    private void SpawnPortals()
    {
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        for (int i = 0; i < Portals.Length; i++)
        {
            Portals[i].SetActive(true);
        }
    }
}
