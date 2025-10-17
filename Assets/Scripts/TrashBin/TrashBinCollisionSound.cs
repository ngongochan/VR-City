using UnityEngine;
using System.Collections;

public class TrashBinSound : MonoBehaviour
{
    // used to play sound when some trash is thrown into the trash bin
    private AudioSource audioSource;
    private AudioClip trashBinCollisionSound;

    void OnCollisionEnter(Collision collision) {
        if(audioSource && trashBinCollisionSound) {
            audioSource.PlayOneShot(trashBinCollisionSound);
        }
    }
}