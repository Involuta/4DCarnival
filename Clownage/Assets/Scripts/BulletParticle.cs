using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    public ParticleSystem bullet;
    public float damage = 10;


    public GameObject Spark;
    List<ParticleCollisionEvent> colEvents = new List<ParticleCollisionEvent>();

    private void OnParticleCollision(GameObject other)
    {
        int events = bullet.GetCollisionEvents(other, colEvents);
        for (int i = 0; i < events; i++)
        {
            Instantiate(Spark, colEvents[i].intersection, Quaternion.LookRotation(colEvents[i].normal));
        }
        if (other.TryGetComponent(out Target target))
        {
            target.TakeDamage(damage);
        }
    }
}
