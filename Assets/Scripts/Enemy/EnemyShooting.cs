using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Nightmare
{
    public class EnemyShooting : PausibleObject
    {
        public int damagePerShot = 20;
        public float timeBetweenBullets = 1.5f;
        public float range = 10f;
        public float spread = 5f;

        public int bulletsPerTap = 5;

        float timer;
        Ray shootRay = new Ray();
        RaycastHit shootHit;
        int shootableMask;
        ParticleSystem gunParticles;
        LineRenderer gunLine;
        AudioSource gunAudio;
        Light gunLight;
        //public Light faceLight;
        float effectsDisplayTime = 0.2f;

        bool readyToShoot = true;
        int bulletsShot;

        //private UnityAction listener;

        void Awake()
        {
            // Create a layer mask for the Shootable layer.
            shootableMask = LayerMask.GetMask("Shootable", "Player", "Pet");

            // Set up the references.
            gunParticles = GetComponent<ParticleSystem>();
            gunLine = GetComponent<LineRenderer>();
            gunAudio = GetComponent<AudioSource>();
            gunLight = GetComponent<Light>();
            damagePerShot = damagePerShot * MainManager.Instance.difficulty;
           //faceLight = GetComponentInChildren<Light> ();

           StartPausible();
        }

        void OnDestroy()
        {
            StopPausible();
        }

        void Update()
        {
            if (isPaused)
                return;

            // Add the time since Update was last called to the timer.
            timer += Time.deltaTime;

            if (timer >= timeBetweenBullets && Time.timeScale != 0)
            {
                // If the Fire1 button is being press and it's time to fire...
                //if (Input.GetButton("Fire1"))
                //{
                    // ... shoot the gun.
                    Shoot();
                //}
            }

            // If there is input on the shoot direction stick and it's time to fire...
            //if ((CrossPlatformInputManager.GetAxisRaw("Mouse X") != 0 || CrossPlatformInputManager.GetAxisRaw("Mouse Y") != 0) && timer >= timeBetweenBullets)
            //{
            //    // ... shoot the gun
            //    Shoot();
            //}

            // If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
            if (timer >= timeBetweenBullets * effectsDisplayTime)
            {
                // ... disable the effects.
                DisableEffects();
            }
        }


        public void DisableEffects()
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


            for (int i = 0; i < bulletsPerTap; i++)
            {

                Vector3 spreadDirection = Quaternion.Euler(0, Random.Range(-spread, spread), 0) * transform.forward;
                shootRay.direction = spreadDirection;
                

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
                    PlayerHealth playerHealth = shootHit.collider.GetComponent<PlayerHealth>();
                    MushroomHealth mushroomHealth = shootHit.collider.GetComponent<MushroomHealth>();
                    CactusHealth cactusHealth = shootHit.collider.GetComponent<CactusHealth>();
                    // If the EnemyHealth component exist...
                    if(mushroomHealth != null)
                    {
                        mushroomHealth.TakeDamage(damagePerShot);
                    }
                    if (cactusHealth != null)
                    {
                        cactusHealth.TakeDamage(damagePerShot);
                    }
                    if (playerHealth != null)
                    {
                        // ... the enemy should take damage.
                        playerHealth.TakeDamage(damagePerShot);
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



    }

}
