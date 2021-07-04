using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health;
    [SerializeField] FirstPersonAIO movement;
    [SerializeField] SpellManager spellManager;



    public void TakeDamage(int amt)
    {
        health -= amt;
        if(health <= 0)
        {
            //Dead
            UIManager.instance.ShowDeathScreen();
            movement.enabled = false;
            spellManager.enabled = false;
        }
    }
}
