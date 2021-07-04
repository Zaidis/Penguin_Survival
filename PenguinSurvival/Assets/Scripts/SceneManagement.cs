using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement instance;

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
    public void LoadScene(string levelName)
    {
        if(levelName == "Quit")
        {
            Application.Quit();
        }
        Time.timeScale = 1;
        SceneManager.LoadScene(levelName);
    }
}
