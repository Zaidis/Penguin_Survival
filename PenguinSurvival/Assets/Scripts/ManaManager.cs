using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaManager : MonoBehaviour
{
    public int maxAmount = 100;
    public float perc = 100f;
    [SerializeField] private int manaAmount;

    private void Start() {
        manaAmount = 0;
        DecreaseManaAmount(0);
    }
    public void SetMana() {
        perc = 200f;
        maxAmount = 200;
        float fill = manaAmount / perc;
        UIManager.instance.SetManaBar(fill);
    }
    public void DecreaseManaAmount(int diff) {
        manaAmount -= diff;
        if(manaAmount <= 0) {
            manaAmount = 0;
        }
        float fill = manaAmount / perc;
        UIManager.instance.SetManaBar(fill);
        UIManager.instance.SetManaText(manaAmount);
    }
    public void IncreaseManaAmount(int sum) {
        manaAmount += sum;
        if(manaAmount >= 100) {
            manaAmount = 100;
        }
        float fill = manaAmount / perc;
        UIManager.instance.SetManaBar(fill);
        UIManager.instance.SetManaText(manaAmount);
    }

    public int GetManaAmount() {
        return manaAmount;
    }


}
