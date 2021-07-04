using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zooSounds : MonoBehaviour
{

    private void Awake() {
        gameObject.GetComponent<AudioSource>().outputAudioMixerGroup = GameObject.Find("Player").GetComponent<AudioSource>().outputAudioMixerGroup;
    }

    private void Start() {
        int num = Random.Range(0, 100);
        print(num);
        if (num > 90) {
            gameObject.GetComponent<AudioSource>().Play();
        }
    }

}
