using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 10f;
    
    public void TakeDamage(float dmg)
    {
        health = health - dmg;
        if (health <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
