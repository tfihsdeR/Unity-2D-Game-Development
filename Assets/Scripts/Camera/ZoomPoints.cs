using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomPoints : MonoBehaviour
{
    [SerializeField] private GameObject mainCam;

    private CameraController camScript;
    private float timer;
    private bool startTimer = false;

    private void Awake() 
    {
        camScript = mainCam.GetComponent<CameraController>();
    }

    private void Update() 
    {
        if (startTimer)
        {
            timer += Time.deltaTime;
                
                if (timer > 3.5)
                {
                    camScript.currentIndex = 0;
                    camScript.orthSize = 5f;
                    startTimer = false;
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            camScript.currentIndex++;
            GetComponent<BoxCollider2D>().enabled = false;
            startTimer = true;
        }
    }
}
