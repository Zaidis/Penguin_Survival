using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicalDoor : MonoBehaviour
{
    private void Start() {
        Physics.IgnoreLayerCollision(1, 8);
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.CompareTag("Player")) {
            if (collision.collider.gameObject.GetComponent<SpellManager>().ultimateUsed) {
                collision.collider.gameObject.GetComponent<SpellManager>().ultTimer = 0;
                Destroy(this.gameObject);
            }
        }
    }

}
