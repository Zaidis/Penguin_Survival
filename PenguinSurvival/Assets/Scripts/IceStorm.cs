using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;
public class IceStorm : MonoBehaviour
{

    private float deathTimer = 10;
    private void Awake() {

        gameObject.GetComponent<AudioSource>().outputAudioMixerGroup = GameObject.Find("Player").GetComponent<AudioSource>().outputAudioMixerGroup;

    }
    private void Update() {
        deathTimer -= Time.deltaTime;
        if(deathTimer <= 0) {
            Collider[] hits = Physics.OverlapSphere(this.transform.position, 8);
            foreach(var hitCollider in hits) {
                if (hitCollider.CompareTag("Enemy")) {
                    EnemyHealth theEnemy = hitCollider.GetComponent<EnemyHealth>();
                    theEnemy.ResetSpeed();
                }
            }
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy")) {
            other.GetComponent<EnemyHealth>().ReduceSpeed();
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHealth>().ReduceSpeed();
        }
    }



    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Enemy")) {
            other.GetComponent<EnemyHealth>().ResetSpeed();
        }
    }
}
