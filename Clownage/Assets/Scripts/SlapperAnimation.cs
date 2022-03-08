using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class SlapperAnimation : MonoBehaviour
{
    private EnemyAIBehavior ai;
    private CycleAnimation walkAnimation;

    private AimConstraint aim;

    // Start is called before the first frame update
    void Start()
    {
        aim = GetComponent<AimConstraint>();
        while (aim.sourceCount > 0)
        {
            aim.RemoveSource(0);
        }
        ConstraintSource constraint = new ConstraintSource();
        constraint.sourceTransform = GameObject.Find("PlayerCapsule").transform;
        constraint.weight = 1;
        aim.AddSource(constraint);

        ai = gameObject.GetComponentInParent<EnemyAIBehavior>();
        walkAnimation = gameObject.GetComponent<CycleAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!ai.playerInAttackRange)
        {
            walkAnimation.enabled = true;
        }
        else
        {
            walkAnimation.enabled = false;
        }
    }
}
