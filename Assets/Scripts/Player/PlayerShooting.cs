using UnityEngine;
using UnityEngine.Events;
using System.Text;
using UnitySampleAssets.CrossPlatformInput;
using System.Collections;

namespace Nightmare
{
    public class PlayerShooting : PausibleObject
    {
        public int damagePerShot = 20;
        public int bulletsPerTap = 3;
        public float timeBetweenBullets = 0.15f;
        public float range = 100f;
        public GameObject grenade;
        public float grenadeSpeed = 200f;
        public float grenadeFireDelay = 0.5f;
        public float spread = 2f;

        float timer;
        Ray shootRay = new Ray();
        RaycastHit shootHit;
        int shootableMask;
        ParticleSystem gunParticles;
        LineRenderer gunLine;
        AudioSource gunAudio;
        Light gunLight;
        WeaponManager weaponManager;
		//public Light faceLight;
        float effectsDisplayTime = 0.2f;
        int grenadeStock = 99;
        int bulletsShot;
        float spreadShot;
        bool readyToShoot = true;

        public int weapon = 0;
  
        private UnityAction listener;

        void Awake ()
        {

            // Create a layer mask for the Shootable layer.
            shootableMask = LayerMask.GetMask ("Shootable", "Enemy");

            // Set up the references.
            gunParticles = GetComponent<ParticleSystem> ();
            gunLine = GetComponent <LineRenderer> ();
            gunAudio = GetComponent<AudioSource> ();
            gunLight = GetComponent<Light> ();
            weaponManager = FindObjectOfType<WeaponManager>();
			//faceLight = GetComponentInChildren<Light> ();

            AdjustGrenadeStock(0);

            listener = new UnityAction(CollectGrenade);

            EventManager.StartListening("GrenadePickup", CollectGrenade);

            StartPausible();
        }

        void OnDestroy()
        {
            EventManager.StopListening("GrenadePickup", CollectGrenade);
            StopPausible();
        }

        void Update ()
        {
            if (isPaused)
                return;

            weapon = weaponManager.selectedWeapon;
            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

#if !MOBILE_INPUT
            if (timer >= timeBetweenBullets && Time.timeScale != 0 && readyToShoot)
            {
                // If the Fire1 button is being press and it's time to fire...
                if (Input.GetButton("Fire2") && grenadeStock > 0)
                {
                    // ... shoot a grenade.
                    ShootGrenade();
                }

                // If the Fire1 button is being press and it's time to fire...
                else if (Input.GetButton("Fire1") && (weapon == 0 || weapon == 1))
                {
                    // ... shoot the gun.
                    bulletsShot = bulletsPerTap;
                    spreadShot = spread;
                    readyToShoot = false;
                    Shoot();
                }
            }
            
#else
            // If there is input on the shoot direction stick and it's time to fire...
            if ((CrossPlatformInputManager.GetAxisRaw("Mouse X") != 0 || CrossPlatformInputManager.GetAxisRaw("Mouse Y") != 0) && timer >= timeBetweenBullets)
            {
                // ... shoot the gun
                Shoot();
            }
#endif
            // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
            if(timer >= timeBetweenBullets * effectsDisplayTime)
            {
                // ... disable the effects.
                DisableEffects ();
            }
        }


        public void DisableEffects ()
        {
            // Disable the line renderer and the light.
            gunLine.enabled = false;
			//faceLight.enabled = false;
            gunLight.enabled = false;
        }
        void Shoot ()
        {
            // Reset the timer.
            timer = 0f;

            // Play the gun shot audioclip.
            gunAudio.Play();

            // Enable the lights.
            gunLight.enabled = true;

            // Stop the particles from playing if they were, then start the particles.
            gunParticles.Stop();
            gunParticles.Play();

            shootRay.origin = transform.position;
            if (weapon == 0)
            {
                bulletsShot = 1;
                shootRay.direction = transform.forward;
            }
            else if (weapon == 1)
            {
                bulletsShot = bulletsPerTap;
            }

            for (int i = 0; i < bulletsShot; i++)
            {
                if (weapon == 1)
                {
                    Vector3 spreadDirection = Quaternion.Euler(0, Random.Range(-spread, spread), 0) * transform.forward;
                    shootRay.direction = spreadDirection;
                }

                // Create a new LineRenderer for each bullet
                LineRenderer bulletLine = new GameObject("BulletLine").AddComponent<LineRenderer>();
                bulletLine.material = gunLine.material;
                bulletLine.startWidth = gunLine.startWidth;
                bulletLine.endWidth = gunLine.endWidth;
                bulletLine.positionCount = 2;
                bulletLine.SetPosition(0, transform.position);

                // Perform the raycast against gameobjects on the shootable layer and if it hits something...
                if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
                {
                    // Try and find an EnemyHealth script on the gameobject hit.
                    EnemyHealth enemyHealth = shootHit.collider.GetComponent<EnemyHealth>();

                    // If the EnemyHealth component exist...
                    if (enemyHealth != null)
                    {
                        // ... the enemy should take damage.
                        enemyHealth.TakeDamage(damagePerShot, shootHit.point);
                    }

                    // Set the second position of the line renderer to the point the raycast hit.
                    bulletLine.SetPosition(1, shootHit.point);
                }
                // If the raycast didn't hit anything on the shootable layer...
                else
                {
                    // ... set the second position of the line renderer to the fullest extent of the gun's range.
                    bulletLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
                }

                // Start a coroutine to disable the LineRenderer after a delay
                StartCoroutine(DisableLineAfterDelay(bulletLine, 0.2f));
            }

            readyToShoot = true;
        }

        private IEnumerator DisableLineAfterDelay(LineRenderer line, float delay)
        {
            yield return new WaitForSeconds(delay);
            Destroy(line.gameObject);
        }

        private void ChangeGunLine(float midPoint)
        {
            AnimationCurve curve = new AnimationCurve();

            curve.AddKey(0f, 0f);
            curve.AddKey(midPoint, 0.5f);
            curve.AddKey(1f, 1f);

            gunLine.widthCurve = curve;
        }

        public void CollectGrenade()
        {
            AdjustGrenadeStock(1);
        }

        private void AdjustGrenadeStock(int change)
        {
            grenadeStock += change;
            GrenadeManager.grenades = grenadeStock;
        }

        void ShootGrenade()
        {
            AdjustGrenadeStock(-1);
            timer = timeBetweenBullets - grenadeFireDelay;
            GameObject clone = PoolManager.Pull("Grenade", transform.position, Quaternion.identity);
            EventManager.TriggerEvent("ShootGrenade", grenadeSpeed * transform.forward);
            //GameObject clone = Instantiate(grenade, transform.position, Quaternion.identity);
            //Grenade grenadeClone = clone.GetComponent<Grenade>();
            //grenadeClone.Shoot(grenadeSpeed * transform.forward);
        }
    }
}