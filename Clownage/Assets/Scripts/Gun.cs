using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
    public class Gun : MonoBehaviour
    {
        public float damage = 2.0f;

        private StarterAssetsInputs _input;
        public Camera gunCam;
        void Start()
        {
            _input = GetComponentInParent<StarterAssetsInputs>();
            _input.shoot = false;
        }

        // Update is called once per frame
        void Update()
        {
            if (_input.shoot)
            {
                Shoot();
                _input.shoot = false;
            }
        }

        void Shoot()
        {
            RaycastHit hit;
            if (Physics.Raycast(gunCam.transform.position, gunCam.transform.forward, out hit))
            {
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }
    }
}