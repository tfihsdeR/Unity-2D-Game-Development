using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject[] bullets;

    private float cooldownTimer = 5;
    private bool facingRight = true;
    private float direction;


    private Animator anim;


    private void Awake() 
    {
        anim = GetComponent<Animator>();
    }


    private void Update() 
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);
        direction = player.transform.position.x - transform.position.x;

        if (direction < 0 && facingRight)
        {
            Flip();
        }
        if (direction > 0 && !facingRight)
        {
            Flip();
        }

        if (distance < 9.6)
        {
            if (cooldownTimer > attackCooldown)
            {
                cooldownTimer = 0;
                anim.SetTrigger("Attack");
            }
        }

        cooldownTimer += Time.deltaTime;
    }


    private void Attack()
    {
        int i = FindBullet();

        bullets[i].transform.position = firePoint.position;
        bullets[i].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }


    private int FindBullet()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            if (!bullets[i].activeInHierarchy)
                return i;
            
        }

        return 0;
    }


    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 tmpScale = transform.localScale;
        tmpScale.x *= -1;
        transform.localScale = tmpScale;
    }
}
