using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 10f;

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0){
            Die();
        }
        Debug.Log(gameObject.name + " says ow");
    }

    public void Die(){
        Destroy(gameObject);
    }
}
