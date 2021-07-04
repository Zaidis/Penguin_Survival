using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    FirstPersonAIO movement;
    [SerializeField] SpellManager spellManager;
    float resetSpeed, resetSprintSpeed;
    float timer = 0;
    float timeToReach;
    float slowedSpeed;
    bool slowed = false;

    private void Awake()
    {
        movement = GetComponent<FirstPersonAIO>();
        resetSpeed = movement.walkSpeed;
        slowedSpeed = movement.walkSpeed / 2;
        resetSprintSpeed = movement.sprintSpeed;
    }

    private void Update()
    {
        if(spellManager.ultimateUsed && slowed)
        {
            ResetSpeed();
        }
        
        if(slowed && timer >= timeToReach)
        {
            ResetSpeed();
        }else if (slowed)
        {
            timer += Time.deltaTime;
        }
    }

    public void GetTranqed(float amt)
    {
        /*
        if (!spellManager.ultimateUsed)
        {
            slowed = true;
            timeToReach += amt;
            //timer = 0;
            movement.walkSpeed = slowedSpeed;
            movement.sprintSpeed = slowedSpeed;
            UIManager.instance.ToggleTranqUI(true);
        }
        */
        slowed = true;
        timeToReach += amt;
        //timer = 0;
        print("Tranq for " + (timeToReach - timer));
        movement.walkSpeed = slowedSpeed;
        movement.sprintSpeed = slowedSpeed;
        UIManager.instance.ToggleTranqUI(true);

    }

    public void ResetSpeed()
    {
        slowed = false;
        timer = 0;
        timeToReach = 0;
        movement.walkSpeed = resetSpeed;
        movement.sprintSpeed = resetSprintSpeed;
        UIManager.instance.ToggleTranqUI(false);
    }


}
