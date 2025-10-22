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

    // left trigger: brake (StopScooter())
    // right trigger: speed (MoveScooterForward())

    // left trigger: turn on/off the light
    // right trigger: honk sound


    //  virtual void OnGrab(Grabber grabber):  Item has been grabbed by a Grabber
    //  virtual void OnRelease(): Has been dropped from the Grabber
    //  virtual void OnGrip(float gripValue): Amount of Grip(0-1)
    //  virtual void OnTrigger(float triggerValue):  Amount of Trigger being held down on the grabbed items controller
    //  virtual void OnTriggerDown(): Fires if trigger was pressed down on this controller this frame
    //  virtual void OnTriggerUp(): Fires if trigger was released on this controller this frame
    //  virtual void OnButton1(): Button 1 is being held down this frame but not last Oculus : Button 1 = "A" if held in Right controller
    //  virtual void OnButton1Down(): Button 1 Pressed down this frame Oculus : Button 1 = "A" if held in Right controller
    //  virtual void OnButton1Up(): Button 1 Released this frame Oculus : Button 1 = "A" if held in Right controller
    //  virtual void OnButton2(): Button 2 is being held down this frame but not last Oculus : Button 2 = "B" if held in Right controller
    //  virtual void OnButton2Down(): Button 2 Pressed down this frame Oculus : Button 2 = "B" if held in Right controller
    //  virtual void OnButton2Up(): Button 2 Released this frame Oculus : Button 2 = "B" if held in Right controller
    //  Protected Attributes
    //  Grabbable grab
    //  Grabber thisGrabber
    //  Grabber thisGrabber


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    
    // Update or FixedUpdate
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