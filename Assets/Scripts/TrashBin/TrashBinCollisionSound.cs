using UnityEngine;
using System.Collections;

public class TrashBinSound : MonoBehaviour
{
    // used to play sound when some trash is thrown into the trash bin
    private AudioSource audioSource;
    public AudioClip trashBinCollisionSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (audioSource && trashBinCollisionSound)
        {
            audioSource.PlayOneShot(trashBinCollisionSound);
            //Debug.Log("Some trash was just thrown into the bin!");
        } else
        {
            Debug.Log("Something's wrong");
            //Debug.Log(trashBinCollisionSound);
            //Debug.Log(audioSource);
        }
    }
}