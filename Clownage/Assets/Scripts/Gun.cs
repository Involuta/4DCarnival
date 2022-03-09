using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;
using TMPro;

namespace StarterAssets
{
    public class Gun : MonoBehaviour
    {
        public float damage = 2.0f;
        public float firerate = 20.0f;
        public int magazineSize = 30;
        private int magazine;
        public int reserveAmmo = 90;
        public int maxReserveAmmo = 90;
        public float reloadSpeed = 2.0f;
        public Text ammoDisplay; 
        private StarterAssetsInputs _input;
        public Camera gunCam;

        public ParticleSystem bullet;

        private float timeUntilShoot = 0f;
        private bool reloading;
        void Start()
        {
            _input = GetComponentInParent<StarterAssetsInputs>();
            _input.shoot = false;
            magazine = magazineSize;
            reloading = false;
            GameObject[] hudElems = GameObject.FindGameObjectsWithTag("HUD");
            foreach (GameObject elem in hudElems)
            {
                if (elem.name == "Ammo readout")
                    ammoDisplay = elem.GetComponent<Text>();
            }
            reserveAmmo = maxReserveAmmo;
        }

        // Update is called once per frame
        void Update()
        {
            if (reloading)
            {
                return;
            }
            if (_input.shoot && !_input.isPaused && Time.time >= timeUntilShoot && magazine > 0)
            {
                timeUntilShoot = Time.time + 1f/firerate;
                Shoot();
                magazine--;
            }
            ammoDisplay.text = magazine.ToString() + " / " + reserveAmmo.ToString();
            if (_input.reload && magazine < magazineSize)
            {
                StartCoroutine(Reload());
                return;
            }
        }

        IEnumerator Reload()
        {
            ammoDisplay.text = "RELOADING";
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