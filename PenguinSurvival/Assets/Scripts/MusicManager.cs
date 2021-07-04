using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{

    [SerializeField] private List<AudioClip> music = new List<AudioClip>();
    AudioSource source;

    private MusicManager instance;
    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }

    private void Start() {
        source = GetComponent<AudioSource>();

        StartCoroutine(Play());
    }

    private IEnumerator Play() {

        while (true) {
            source.clip = music[Random.Range(0, music.Count)];
            source.Play();
            yield return new WaitForSeconds(source.clip.length);
        }

    }
}
