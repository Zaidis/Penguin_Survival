using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SpellManager : MonoBehaviour
{
    [SerializeField] private GameObject iceStorm;
    [SerializeField] private GameObject kineticLift;
    [SerializeField] private GameObject fireSpot;
    [SerializeField] private Camera mainCam;
    [SerializeField] public bool ultimateUsed;
    [SerializeField] public float ultTimer;
    [SerializeField] private GameObject rainbow;
    private void Update() {
        ultTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E)) { //Ice Storm
            if(gameObject.GetComponent<ManaManager>().GetManaAmount() >= 20) {
                //cast spell
                gameObject.GetComponent<ManaManager>().DecreaseManaAmount(20); //reduces mana by 20
                GameObject ice = Instantiate(iceStorm, transform.position, Quaternion.identity);
                //ice.transform.position = gameObject.transform.position;
            }
        }
        if (Input.GetKeyDown(KeyCode.Q)) { //Lift off

            if(gameObject.GetComponent<ManaManager>().GetManaAmount() >= 40) {
                gameObject.GetComponent<ManaManager>().DecreaseManaAmount(40);
                GameObject push = Instantiate(kineticLift, transform.position + transform.forward, Quaternion.identity);
                push.transform.forward = gameObject.transform.forward;
            }

        }
        if (Input.GetKeyDown(KeyCode.F)) { //#mario

            if(gameObject.GetComponent<ManaManager>().GetManaAmount() >= 100) {
                gameObject.GetComponent<ManaManager>().DecreaseManaAmount(100);
                ultTimer = 10;
            }

        }
        if(ultTimer <= 0) {
            ultTimer = 0;
            ultimateUsed = false;
            rainbow.SetActive(false);
        } else {
            ultimateUsed = true;
            rainbow.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.CompareTag("Enemy")) {
            print("I hit an enemy");
            if (ultimateUsed == true) {
                print("Dealing damage");
                collision.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
            }
        }
    }
}
