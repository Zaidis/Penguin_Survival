using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    [SerializeField] private bool dmgUp;
    [SerializeField] private bool speedUp;
    [SerializeField] private bool manaUp;

    public void SetDamageUp(bool power) {
        dmgUp = power;
    }
    public bool GetDamageUp() {
        return dmgUp;
    }

    public void SetSpeedUp(bool power) {
        speedUp = power;
    }
    public bool GetSpeedUp() {
        return speedUp;
    }

    public void SetManaUp(bool power) {
        manaUp = power;
    }
    public bool GetManaUp() {
        return manaUp;
    }
}
