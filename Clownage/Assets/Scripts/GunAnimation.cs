using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
    public class GunAnimation : MonoBehaviour
    {
        private StarterAssetsInputs _input;

        private CycleAnimation animator;

        // Start is called before the first frame update
        void Start()
        {
            _input = GetComponentInParent<StarterAssetsInputs>();
            animator = gameObject.GetComponent<CycleAnimation>();
        }

        // Update is called once per frame
        void Update()
        {
            if (_input.shoot)
            {
                animator.imagesToCycle = animator.attackImages;
            }
            else
            {
                animator.imagesToCycle = animator.neutralImages;
            }
        }
    }
}
