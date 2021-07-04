using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangerShoot : MonoBehaviour
{
    [SerializeField] ZookeeperMovement movementScript;
    [SerializeField] float range;
    [SerializeField] float timeToReload = 3f;
    float timer = 0;
    [SerializeField] GameObject bullet;
    [SerializeField] float bulletLifeTime = 4f;
    [SerializeField] float bulletSpeed = 4f;
    [SerializeField] Transform firePoint;
    [SerializeField] float tranqPower = 3f;


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timeToReload && movementScript.DistanceToTarget() <= range)
        {
            //Within range... FIRE!
            Fire();
        }
    }

    void Fire()
    {
        timer = 0;
        GameObject bul = Instantiate(bullet, firePoint.position, Quaternion.identity);
        bul.transform.rotation = this.transform.rotation;
        TranqShot shot = bul.GetComponent<TranqShot>();
        shot.speed = bulletSpeed;
        shot.lifeTime = bulletLifeTime;
        shot.tranqPower = tranqPower;

    }



    void OnDrawGizmosSelected()
    {
        // Display the explosion radius when selected
        Gizmos.color = new Color(1, 1, 0, 0.75F);
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
