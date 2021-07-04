using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class KineticPush : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float deathTimer;
    private float secondTimer;
    [SerializeField] private float maxHeight;
    [SerializeField] private float dropForce = 30;
    [SerializeField] private int damage;
   // [SerializeField] private SpellManager spellManager;
    public List<GameObject> enemies = new List<GameObject>();
    public List<Vector3> heights = new List<Vector3>();
    private void Awake() {
        gameObject.GetComponent<AudioSource>().outputAudioMixerGroup = GameObject.Find("Player").GetComponent<AudioSource>().outputAudioMixerGroup;
    }
    private void Update() {
        deathTimer -= Time.deltaTime;
        gameObject.transform.localScale += new Vector3(1.5f, 0, 0) * Time.deltaTime;
        transform.position += transform.forward * speed * Time.deltaTime;
        Lift();
        if(deathTimer <= 0) {
            Drop(); 
        }
    }
    private void Lift() {

        for (int i = 0; i < enemies.Count; i++) {
            if(enemies[i] != null)
            {
                if (enemies[i].transform.position.y < heights[i].y + maxHeight)
                {
                    enemies[i].transform.position += transform.up * Time.deltaTime * speed;
                }
                else
                {
                    enemies[i].transform.position = heights[i] + new Vector3(0, maxHeight, 0);

                }
            }else
            {
                enemies.RemoveAt(i);
                heights.RemoveAt(i);
            }

            
        }
    }
    private void Drop() {
        if(enemies.Count == 0) {
            Destroy(this.gameObject);
        }
        for (int i = 0; i < enemies.Count; i++) {

            if(enemies[i] != null)
            {
                enemies[i].transform.position += -transform.up * Time.deltaTime * dropForce;
                if (enemies[i].transform.position.y <= heights[i].y)
                {
                    print("Jake is dum");
                    enemies[i].GetComponent<NavMeshAgent>().enabled = true;
                    enemies[i].GetComponent<ZookeeperMovement>().enabled = true;
                    enemies[i].GetComponent<Rigidbody>().useGravity = true;
                    enemies[i].transform.GetChild(0).GetComponent<EnemyHealth>().TakeDamage(damage);
                    enemies.RemoveAt(i);
                    heights.RemoveAt(i);

                }
            }else
            {
                enemies.RemoveAt(i);
                heights.RemoveAt(i);
            }

            
        }

    }
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Enemy")) {
            GameObject obj = other.transform.parent.gameObject;
            obj.GetComponent<NavMeshAgent>().enabled = false;
            obj.GetComponent<ZookeeperMovement>().enabled = false;
            obj.GetComponent<Rigidbody>().useGravity = false;
            obj.GetComponent<Rigidbody>().velocity = Vector3.zero;
            heights.Add(obj.transform.position);
            enemies.Add(other.transform.parent.gameObject);
            //spellManager.KineticLift(other.transform.parent.gameObject);
            //other.gameObject.GetComponent<EnemyHealth>().TakeDamage(1);
        }
    }
}
