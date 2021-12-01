
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Shooting : MonoBehaviour
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


    enum Weapons { Rifle, Shotgun, Pistol};
    Weapons equipped;

    void Start()
    {
        shootCD = 0f;
        equipped = Weapons.Rifle;
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
                case Weapons.Rifle:
                    Debug.Log("Apua");
                    Instantiate(projectile, projectileSpawn.transform.position, Quaternion.identity);
                    break;

                case Weapons.Shotgun:
                    break;

                case Weapons.Pistol:
                    break;


            }

            
            shootOnCD = true;
            StartCoroutine(ShootCooldown());
        }

        if(Input.GetButtonDown("Weapon1"))
        {
            equipped = Weapons.Rifle;
            previousWeapon.SetActive(false);
            previousWeapon = rifle;
            rifle.SetActive(true);
            //Debug.Log("Equip rifle");
        }

        if (Input.GetButtonDown("Weapon2"))
        {
            equipped = Weapons.Shotgun;
            previousWeapon.SetActive(false);
            previousWeapon = shotgun;
            shotgun.SetActive(true);
        }

        if (Input.GetButtonDown("Weapon3"))
        {
            equipped = Weapons.Pistol;
            previousWeapon.SetActive(false);
            previousWeapon = pistol;
            pistol.SetActive(true);
        }
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(0.2f);
        shootOnCD = false;
    }


}
