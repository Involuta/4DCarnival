using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;

namespace StarterAssets
{
    public class Sniper : MonoBehaviour
    {
        public float damage = 2.0f;
        public float firerate = 20.0f;
        public int magazineSize = 30;
        private int magazine;
        public int reserveAmmo = 90;
        public int maxReserveAmmo = 90;

        private StarterAssetsInputs _input;
        public Camera gunCam;

        public Text ammoDisplay; 
        public ParticleSystem bullet;
        public float reloadSpeed = 4f;

        private float timeUntilShoot = 0f;
        private bool reloading = false;
        void Start()
        {
            _input = GetComponentInParent<StarterAssetsInputs>();
            bullet.GetComponent<BulletParticle>().damage = damage;
            magazine = magazineSize;
            reserveAmmo = maxReserveAmmo;
        }

        // Update is called once per frame
        void Update()
        {   
            if (reloading)
            {
                return;
            }
            if (_input.reload && magazine < magazineSize)
            {
                StartCoroutine(Reload());
                return;
            }
            if (_input.shoot && !_input.isPaused && Time.time >= timeUntilShoot && magazine > 0)
            {
                timeUntilShoot = Time.time + 1f/firerate;
                Shoot();
                magazine--;
                _input.shoot = false;
            }
            ammoDisplay.text = magazine.ToString() + " / " + reserveAmmo.ToString();
        }
        IEnumerator Reload()
        {
            ammoDisplay.text = "-- / --";
            reloading = true;
            yield return new WaitForSeconds(reloadSpeed);

            int ammoChange = Mathf.Min(magazineSize - magazine, reserveAmmo);
            magazine = magazine + ammoChange;
            reserveAmmo = reserveAmmo - ammoChange;
            ammoDisplay.text = magazine.ToString() + " / " + reserveAmmo.ToString();
            _input.reload = false;
            reloading = false;
        }

        void Shoot()
        {
            bullet.Play();
        }

    }
}