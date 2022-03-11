using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.AI;

public class UnicyclistAnimation : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent ai;
    private CycleAnimation animator;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerCapsule").transform;
        ai = gameObject.GetComponentInParent<NavMeshAgent>();
        animator = gameObject.GetComponent<CycleAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        float dotProduct = Vector3.Dot(player.forward, ai.velocity.normalized);

        //if the unicyclist's velocity is to the side compared to how the player's facing, make the cyclist turn to the side.
        //otherwise, face forward
        if (dotProduct <= Mathf.Cos(5*Mathf.PI/5.5f) || dotProduct >= Mathf.Cos(Mathf.PI/5.5f))
        {
            animator.imagesToCycle = animator.attackImages;
        }
        else
        {
            animator.imagesToCycle = animator.neutralImages;
        }
    }
}