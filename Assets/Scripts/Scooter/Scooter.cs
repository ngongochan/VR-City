using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

public class MyScooter : GrabbableEvents
{
    public float Force;
    public ParticleSystem driftingEffect;
    AudioSource audioSource;

    // grip: requirement for the scooter to move;
    // but how to do both hand grabs?
    // left trigger: turn on/off the light
    // right trigger: honk sound

    void Start()
    {
        //GameObject player = GameObject.FindGameObjectWithTag("Player");

        //if (player)
        //{
        //}
        //else
        //{
        //    Debug.Log("No player object found.");
        //}
        audioSource = GetComponent<AudioSource>();
    }
    
    // Update or FixedUpdate in this case?
    void FixedUpdate()
    {
        if (grab != null && grab.BeingHeld)
        {
            //
        }
    }
    public override void OnGrab(Grabber grabber)
    {

    }
    public override void OnTrigger(float triggerValue)
    {
        if (triggerValue > 0.25f)
        {
            MoveScooterForward(triggerValue);
        }
        else
        {
            StopScooter();
        }
        base.OnTrigger(triggerValue);
    }

    //Vector3 moveDirection;

    void MoveScooterForward(float triggerValue)
    {
        //moveDirection = transform.forward * Force;
        transform.position = transform.forward * Force * triggerValue * Time.deltaTime;

        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }

        if (driftingEffect != null && !driftingEffect.isPlaying)
        {
            driftingEffect.Play();
        }
    }
    public override void OnRelease()
    {
        StopScooter();
    }

    public override void OnTriggerUp()
    {
        StopScooter();
        base.OnTriggerUp();
    }

    void StopScooter()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        if (driftingEffect != null && driftingEffect.isPlaying)
        {
            driftingEffect.Stop();
        }
    }
}