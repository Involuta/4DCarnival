using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class UnicyclistAttack : MonoBehaviour
{
    private Random r = new Random();

    Vector3 hitboxBottomSpherePosition;
    Vector3 hitboxTopSpherePosition;
    Vector3 castDirection;

    public float castDistance;
    public float hitboxRadius;

    public LayerMask whatIsPlayer;

    RaycastHit hit;

    public float damage;
    public bool hitboxIsActive;
    public float timeBetweenAttacks;

    // Start is called before the first frame update
    void Start()
    {
        castDirection = Vector3.forward;
    }

    // Update is called once per frame
    void Update()
    {
        hitboxBottomSpherePosition = transform.position + Vector3.down * .2f;
        hitboxTopSpherePosition = transform.position + Vector3.up * .2f;

        if (hitboxIsActive && Physics.CapsuleCast(hitboxBottomSpherePosition, hitboxTopSpherePosition, hitboxRadius, castDirection, out hit, castDistance))
        {
            if (hit.rigidbody != null && hit.rigidbody.tag == "Player")
            {
                StartCoroutine(AttackCooldown());

                damage = r.Next(10, 16);
                Debug.Log("Player Hit by Unicycle");
                hit.rigidbody.GetComponent<TakeDamage>().TakeDamageNow(damage);
            }
        }
    }

    private IEnumerator AttackCooldown()
    {
        hitboxIsActive = false;
        yield return new WaitForSeconds(timeBetweenAttacks);
        hitboxIsActive = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down*.2f, hitboxRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.up*.2f, hitboxRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.up*.2f + Vector3.forward*.2f, hitboxRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.down*.2f + Vector3.forward*.2f, hitboxRadius);

    }
}
