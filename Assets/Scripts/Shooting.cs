
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    float shootCD;
    bool shootOnCD;
    public GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {
        shootCD = 0f;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButton("Fire1") && !shootOnCD)
        {
            //Debug.Log("Jee");
            Debug.DrawRay(playerCamera.transform.position, playerCamera.transform.forward * 100, Color.red, 5f);
            Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward * 100);

            shootOnCD = true;
            StartCoroutine(ShootCooldown());
        }
    }

    IEnumerator ShootCooldown()
    {
        yield return new WaitForSeconds(0.2f);
        shootOnCD = false;
    }
}
