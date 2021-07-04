using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabZone : MonoBehaviour
{
    public float grabCoolDown = 5f;
    public float timer = 0;
    public bool canGrab = true;
    private void Update()
    {
        if(timer < grabCoolDown)
        {
            timer += Time.deltaTime;
        }else
        {
            canGrab = true;
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (canGrab && other.CompareTag("Player"))
        {
            print("Grabbed!");
            canGrab = false;
            timer = 0;
            StartCoroutine(GameManager.instance.StartGrabEvent(this.gameObject));
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
        if(UIManager.instance != null)
        UIManager.instance.ToggleGrabUI(false);
        if(GameManager.instance != null)
        {
            GameManager.instance.SetControls(true);
            GameManager.instance.SetMovement(true);
        }
       
    }

}
