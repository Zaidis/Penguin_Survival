using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private GameObject spawn;
    public float respawnTimer = 60;
    public float maxRespawnTimer;
    public bool waiting;
    private void Start() {
        Spawn();
    }
    private void Update() {
        if (waiting)
            respawnTimer -= Time.deltaTime;

        if (respawnTimer <= 0) {
            respawnTimer = 0;
            Spawn();
            waiting = false;
            respawnTimer = maxRespawnTimer;
        }

    }
    private void Spawn() {
        GameObject obj = Instantiate(spawn, transform.position, Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}