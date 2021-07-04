using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Dmg : MonoBehaviour
{

    private void Update() {
        gameObject.transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, 1), transform.localPosition.z);
        transform.Rotate(0, 15 * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.CompareTag("Player")) {

            if(collision.collider.gameObject.GetComponent<PowerupManager>().GetDamageUp() == false) {
                collision.collider.gameObject.GetComponent<PowerupManager>().SetDamageUp(true);
            }
            Destroy(this.gameObject);
        }    
    }
}
