using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingManager : MonoBehaviour
{

    [SerializeField] private GameObject fireball;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject firePoint;
    private float shootingTimer;
    public float maxShootingTimer = 1;
    private bool canShoot;
    private void Update() {
        shootingTimer -= Time.deltaTime;
        if (shootingTimer <= 0) {
            shootingTimer = 0;
            canShoot = true;
        }
        if (canShoot) {
            if (Input.GetMouseButtonDown(0)) {
                //Shoot fireball
                GameObject projectile = Instantiate(fireball, firePoint.transform.position, Quaternion.identity);
                projectile.transform.forward = cam.transform.forward;
                projectile.gameObject.GetComponent<FireBallMovement>().dmg = 1;
                if (gameObject.GetComponent<PowerupManager>().GetDamageUp()) {
                    projectile.gameObject.GetComponent<FireBallMovement>().dmg *= 2;
                }
                if (gameObject.GetComponent<PowerupManager>().GetSpeedUp()) {
                    maxShootingTimer = 0.5f;
                }
                shootingTimer = maxShootingTimer;
                canShoot = false;
            }
        }
        
    }

}
