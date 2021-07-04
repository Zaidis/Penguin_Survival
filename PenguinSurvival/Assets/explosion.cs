using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    private void Awake() {
        gameObject.GetComponent<AudioSource>().outputAudioMixerGroup = GameObject.Find("Player").GetComponent<AudioSource>().outputAudioMixerGroup;
    }
}
