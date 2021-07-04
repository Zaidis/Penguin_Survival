using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 3;
    [SerializeField] ZookeeperMovement movementScript;

    public void TakeDamage(int amt)
    {
        health -= amt;
        if(health <= 0)
        {
            GameManager.instance.RemoveEnemy(this.transform.parent.gameObject);
            Destroy(this.transform.parent.gameObject);
        }
    }

    public void ReduceSpeed()
    {
        if(movementScript.enabled)
        movementScript.Slowed();
    }

    public void ResetSpeed()
    {
        if (movementScript.enabled)
            movementScript.ResetSpeed();
    }


}
