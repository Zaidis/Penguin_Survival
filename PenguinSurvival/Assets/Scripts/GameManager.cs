using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] Transform playerPos;
    [SerializeField] FirstPersonAIO movement;
    [SerializeField] int keyPressesToLeaveGrab = 20;
    [SerializeField] KeyCode firstKey, secondKey;
    [SerializeField] Animator firstKeyAnim, secondKeyAnim;
    [SerializeField] WaveManager waveManager;

    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else
        {
            Destroy(this.gameObject);
        }
    }

    public Transform GetPlayerTransform()
    {
        return playerPos;
    }

    public void SetMovement(bool trig)
    {
        movement.GetComponent<Rigidbody>().velocity = Vector3.zero;
        movement.enabled = trig;
    }

    public void SetControls(bool trig)
    {
        playerPos.parent.GetComponent<SpellManager>().enabled = trig;
    }
    
    public IEnumerator StartGrabEvent(GameObject enemy)
    {
        SetControls(false);
        SetMovement(false);
        int keysPressed = 0;
        int keyToPress = 1;
        UIManager.instance.ToggleGrabUI(true);
        while(keysPressed < keyPressesToLeaveGrab)
        {
            if(enemy == null)
            {
                break;
            }
            if (Input.GetKeyDown(firstKey) && keyToPress == 1)
            {
                print("Should play");
                firstKeyAnim.ResetTrigger("ButtonHit");
                firstKeyAnim.SetTrigger("ButtonHit");
                keyToPress = 2;
                keysPressed++;
            }else if (Input.GetKeyDown(secondKey) && keyToPress == 2)
            {
                secondKeyAnim.ResetTrigger("ButtonHit");
                secondKeyAnim.SetTrigger("ButtonHit");
                keyToPress = 1;
                keysPressed++;
            }
            yield return null;
        }
        UIManager.instance.ToggleGrabUI(false);
        SetControls(true);
        SetMovement(true);
    }

    public void RemoveEnemy(GameObject enemy)
    {
        waveManager.RemoveEnemyFromList(enemy);
    }

}
