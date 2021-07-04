using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Rainbow : MonoBehaviour
{
    Color color = Color.white;
    private void Update() {
        color = Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1));
        color.a = 0.4f;
        gameObject.GetComponent<Image>().color = color;
    }

}
