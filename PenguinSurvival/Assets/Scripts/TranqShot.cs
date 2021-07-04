using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranqShot : MonoBehaviour
{
    [HideInInspector]
    public float speed, lifeTime, tranqPower;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    void FixedUpdate()
    {
        this.transform.position += this.transform.forward * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            print("GET TRANQED BITCH");
            other.GetComponent<PlayerMovementController>().GetTranqed(tranqPower);
            Destroy(this.gameObject);
        }
        Destroy(this.gameObject);
    }
}
