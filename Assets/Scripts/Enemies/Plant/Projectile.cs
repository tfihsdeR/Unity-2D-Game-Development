using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool hit;
    private float direction;
    private float lifeTime;

    private CircleCollider2D cirCol;
    private Animator anim;


    private void Awake() 
    {
        anim = GetComponent<Animator>();
        cirCol = GetComponent<CircleCollider2D>();
    }


    private void Update() 
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifeTime += Time.deltaTime;
        if (lifeTime > 0.75)
        {
            gameObject.SetActive(false);
            lifeTime = 0;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hit = true;
            cirCol.enabled = false;
            gameObject.SetActive(false);
            lifeTime = 0;
        }
    }


    public void SetDirection(float _direction)
    {
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        cirCol.enabled = true;
    }
}