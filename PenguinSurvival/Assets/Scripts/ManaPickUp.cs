using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPickUp : MonoBehaviour
{

    private void Update() {

        gameObject.transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, 1), transform.localPosition.z);
        transform.Rotate(0, 15 * Time.deltaTime, 0);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.CompareTag("Player")) {
            print("Collected mana");
            collision.collider.gameObject.GetComponent<ManaManager>().IncreaseManaAmount(20);
            gameObject.transform.parent.gameObject.GetComponent<Respawn>().waiting = true;
            Destroy(this.gameObject);
        }
    }
}
