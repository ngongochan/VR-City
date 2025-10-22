using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

// left trigger: brake (StopScooter())
// right trigger: speed (MoveScooterForward())

// "A" to toggle the light
// "X" to honk

public class MyScooter : GrabbableEvents
{
    public float force = 10f;
    public ParticleSystem driftingEffect;
    Rigidbody rb;

    Grabber leftHand, rightHand;

    public AudioSource honkSound;
    public AudioClip honkAudioClip;
    
    public Light drivingLight;

    void Start()
    {
        driftingEffect = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
        honkSound = GetComponentInChildren<AudioSource>();
        drivingLight = GetComponentInChildren<Light>();
        drivingLight.enabled = false;
    }

    // Update or FixedUpdate?
    void FixedUpdate()
    {
        // if (grab != null && grab.BeingHeld)
        // {
        //     //
        // }
        if (leftHand != null && rightHand != null)
        {
            MoveScooterForward(triggerValue);
        }
        else
        {
            StopScooter();
        }
    }
    
    public override void OnGrab(Grabber grabber)
    {
        if(grabber.HandSide == ControllerHand.Left) 
        {
            leftHand = grabber;
        }
        else if(grabber.HandSide == ControllerHand.Right)
        {
            rightHand = grabber;
        }
    }

    public override void OnTrigger(float triggerValue)
    {
        if(leftHand && rightHand)
        {
            MoveScooterForward(triggerValue);
        }
        else
        {
            StopScooter();
        }
    }

    void MoveScooterForward(float triggerValue)
    {
        // transform.position += transform.forward * force * Time.deltaTime;
        rb.AddForce(transform.forward * force, ForceMode.Acceleration);
        // if (driftingEffect != null && !driftingEffect.isPlaying)
        // {
        //     driftingEffect.Play();
        // }
    }

    public override void OnRelease()
    {
        leftHand = null;
        rightHand = null;
        StopScooter();
    }

    void StopScooter()
    {
        rb.velocity = Vector3.zero;
        // if (driftingEffect != null && driftingEffect.isPlaying)
        // {
        //     driftingEffect.Stop();
        // }
        // transform.position += Vector3.zero;
    }

    public override void OnButton1Down()
    {
        if (thisGrabber.HandSide == ControllerHand.Left)
        {
            // left hand press "X" to honk
            Debug.Log("Left hand pressed X");
            Honk();
        }
        else if (thisGrabber.HandSide == ControllerHand.Right)
        {
            // right hand press "A" to toggle the driving light
            Debug.Log("Right hand pressed A");
            ToggleLight();
        }
    }
	
    void Honk()
    {
        if (honkSound)
        {
            honkSound.PlayOneShot(honkAudioClip);
        }
        else
        {
            Debug.Log("Can't honk rn!");
        }
    }

    void ToggleLight() 
    {
        if(drivingLight)
        {
            drivingLight.enabled = !drivingLight.enabled;
        }
    }
}