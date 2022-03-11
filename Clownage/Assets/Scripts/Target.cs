using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 10f;

    void Start()
    {

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0){
            Die();
        }
    }

    public void Die(){
        Scores.yourScore++;
        Destroy(gameObject);
    }
}
