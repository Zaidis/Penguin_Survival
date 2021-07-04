using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private void Awake() {
        player = GameObject.Find("Player");
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (player.GetComponent<SpellManager>().ultimateUsed) {

            } else {
                collision.GetComponent<PlayerHealth>().TakeDamage(1);
            }
        }
    }
}
