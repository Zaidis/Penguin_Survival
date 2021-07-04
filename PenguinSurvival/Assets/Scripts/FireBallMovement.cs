using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallMovement : MonoBehaviour
{
    private float speed = 20;
    private float deathTimer = 1;
    [SerializeField] GameObject explosionObj;
    public int dmg;
    private void Awake() {
        gameObject.GetComponent<AudioSource>().outputAudioMixerGroup = GameObject.Find("Player").GetComponent<AudioSource>().outputAudioMixerGroup;
    }
    private void Update() {
        deathTimer -= Time.deltaTime;
        transform.position += transform.forward * speed * Time.deltaTime;

        if(deathTimer <= 0) {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(dmg);
            Destroy(Instantiate(explosionObj, this.transform.position, Quaternion.identity), 4);
            print("ayyy");
            Destroy(this.gameObject);
        }
    }
}
