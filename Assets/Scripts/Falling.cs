using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour
{
    PlayerLife life;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        life.Die();
    }
}
