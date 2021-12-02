
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    float shootCD;
    bool shootOnCD;
    public GameObject playerCamera;
    public GameObject projectile;
    public GameObject rifle;
    public GameObject shotgun;
    public GameObject pistol;
    public GameObject previousWeapon;
    public GameObject projectileSpawn;

    public AudioSource audios;
    public AudioClip rifleShot;
    public AudioClip shotgunShot;
    public AudioClip pistolShot;

    public TMP_Text ammoText;
    public TMP_Text healthText;

    public int rifleAmmo = 30;
    public int shotgunAmmo = 5;
    public int pistolAmmo = 20;
    public int health = 5;


    enum Weapons { Rifle, Shotgun, Pistol};
    Weapons equipped;

    void Start()
    {
        audios = GetComponent<AudioSource>();
        shootCD = 0f;
        equipped = Weapons.Rifle;
        shootCD = 0.2f;
        previousWeapon = rifle;
        shootOnCD = false;
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetButton("Fire1") && !shootOnCD) // Had problems creating the shooting using raycast so using projectiles instead
        {
            switch(equipped)
            {
                case Weapons.Rifle: //Shoot a bullet every 0.2 seconds when holding down the button
                    if (rifleAmmo > 0)
                    {
                        GameObject bullet = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
                        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
                        bulletRB.velocity = Camera.main.transform.forward * 30f;
                        audios.PlayOneShot(rifleShot);
                        rifleAmmo--;
                    }
                    break;

                case Weapons.Shotgun: //Shoot bullets in a spread (NOT WORKING)
                    if(shotgunAmmo > 0)
                    {
                        for (int i = 0; i < 8; i++)
                        {
                            float x = projectileSpawn.transform.rotation.x + (Random.Range(-3, 3));
                            float y = projectileSpawn.transform.rotation.y + (Random.Range(-3, 3));
                            Vector3 spread = new Vector3(x, y, transform.rotation.z);
                            Quaternion spreadRot = Quaternion.Euler(spread);
                            GameObject shotgunPellet = Instantiate(projectile, projectileSpawn.transform.position, spreadRot);
                            Rigidbody shotgunPelletRB = shotgunPellet.GetComponent<Rigidbody>();
                            shotgunPelletRB.velocity = shotgunPellet.transform.forward * 3f;
                            //shotgunPellet.transform.rotation = spreadRot;
                            //shotgunPelletRB.velocity = transform.InverseTransformDirection(shotgunPellet.transform.forward * 1f);
                            audios.PlayOneShot(shotgunShot);
                            


                            //Vector3 spawnDirection = transform.InverseTransformDirection(shotgunPellet.transform.right);
                            //shotgunPelletRB.velocity = transform.forward * 30f;
                        }
                        shotgunAmmo--;

                    }
                    break;

                case Weapons.Pistol: //Shoot bullets but slow
                    if (pistolAmmo > 0)
                    {
                        GameObject pistolBullet = Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
                        Rigidbody pistolBulletRB = pistolBullet.GetComponent<Rigidbody>();
                        pistolBulletRB.velocity = Camera.main.transform.forward * 30f;
                        pistolAmmo--;
                        audios.PlayOneShot(pistolShot);
                    }
                    break;
            }

            
            shootOnCD = true;
            StartCoroutine(ShootCooldown());
        }

        if(Input.GetButtonDown("Weapon1")) //Change to rifle when pressing 1
        {
            equipped = Weapons.Rifle; //Change equipped weapon
            previousWeapon.SetActive(false); //Hide previously used weapon
            previousWeapon = rifle; //Set "current" previous weapon to rifle
            rifle.SetActive(true); //Show rifle
            shootCD = 0.2f;         //New shooting cooldown
            //Debug.Log("Equip rifle");
        }

        if (Input.GetButtonDown("Weapon2")) //Change to shotgun when pressing 2
        {
            equipped = Weapons.Shotgun;
            previousWeapon.SetActive(false);
            previousWeapon = shotgun;
            shotgun.SetActive(true);
            shootCD = 1f;
        }

        if (Input.GetButtonDown("Weapon3"))//Change to pistol when pressing 3
        {
            equipped = Weapons.Pistol;
            previousWeapon.SetActive(false);
            previousWeapon = pistol;
            pistol.SetActive(true);
            shootCD = 0.5f;
        }

        ammoText.text = "Rifle ammo: " + rifleAmmo + "\n" + "Shotgun ammo: " + shotgunAmmo + "\n" + "Pistol ammo: " + pistolAmmo; //Update ammo
        healthText.text = "Health: " + health; //Update health
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(shootCD);
        shootOnCD = false;
    }

    public void GetAmmo() //Get random amount of ammo when picking up a crate
    {
        rifleAmmo += Random.Range(15, 30);
        shotgunAmmo += Random.Range(3, 8);
        pistolAmmo += Random.Range(20, 30);
    }

    public void TakeDamage()
    {
        health--;
        if(health <= 0)
        {
            Debug.Log("You lose!");
            GameObject.FindObjectOfType<GameManager>().replayButton.SetActive(true);
            GameObject.FindObjectOfType<GameManager>().quitButton.SetActive(true);
            //GameObject.FindGameObjectWithTag("Player").GetComponent<FirstPersonController>().enabled = false;
            //Cursor.visible = true;
            Destroy(this.gameObject);

        }
    }


}
