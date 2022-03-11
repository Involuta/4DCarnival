using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Target : MonoBehaviour
{
    public float health = 10f;
    public GameObject scoreObj;
    //public TextMeshProUGUI scoreText

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
        //scoreText.text = $"Clowns Eliminated: {pts}";
        Destroy(gameObject);
    }
}
