using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float cameraVision = 1.5f;

    private Camera cam;
    public float orthSize = 9f;
    private float defaultOrthSize = 5;

    public int currentIndex = 0;
    private Vector3 currentPos;
    private float timer;

    [SerializeField] private Transform[] positions;
    
    
    private void Awake() 
    {
        cam = Camera.main;
    }

    private void Update() 
    {
        currentPos = positions[currentIndex].position;

        if (currentIndex == 0)
        {
            transform.position = new Vector3(currentPos.x, currentPos.y + cameraVision, transform.position.z);
            cam.orthographicSize = defaultOrthSize;
        }

        if (currentIndex > 0)
        {
            
            transform.position = Vector3.Lerp(transform.position, currentPos, 1f * Time.deltaTime);
            cam.orthographicSize = orthSize;
        }

        if (currentIndex > positions.Length - 1)
        {
            currentIndex = 0;
        }
    }

}