using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject grabUI, tranqUI, deathScreen;
    [SerializeField] private Image manaBar;
    [SerializeField] private TextMeshProUGUI manaText;
    public static UIManager instance;
    [SerializeField] TextMeshProUGUI waveNum;

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

    public void ToggleGrabUI(bool setTo)
    {
        if(grabUI != null)
        grabUI.SetActive(setTo);
    }

    public void SetManaBar(float num) {
        manaBar.fillAmount = num;
    }
    public void SetManaText(int num) {
        manaText.text = num.ToString("0");
    }
    public void ToggleTranqUI(bool setTo)
    {
        print("Turn on TranqUI");
        tranqUI.SetActive(setTo);
    }

    public void UpdateWaveText(int num)
    {
        waveNum.text = "Wave: " + num.ToString();
    }

    public void ShowDeathScreen()
    {
        deathScreen.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
