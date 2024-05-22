using UnityEngine;

public class AudioPlay : MonoBehaviour {

    AudioSource audioSource;

    void Start() {
        audioSource = GetComponent<AudioSource>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.Space)) {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}