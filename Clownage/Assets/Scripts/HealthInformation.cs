using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthInformation : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float maxHealth;

    public float Health { get => health; set => health = value; }
    public float MaxHealth { get => maxHealth; set => maxHealth = value; }
    public float HealthPickupValue = 50;

    // Start is called before the first frame update
    void Start()
    {
        health = 100;
        maxHealth = health;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Health")
        {
            health = health + Mathf.Min(HealthPickupValue, maxHealth - health);
            Destroy(other.gameObject);
        }
    }

}
