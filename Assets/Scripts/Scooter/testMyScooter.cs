using BNG;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

// made some changes to Matt's scripts

public class testMyScooter : GrabbableEvents
{
    public float speed;
    public SteeringWheel steering;
    private Grabber rightHand;

    public ParticleSystem driftingEffect;
    Rigidbody rb;

    public AudioClip honkAudioClip;

    public Light drivingLight;

    public override void OnGrab(Grabber grabber)
    {
        if (grabber.HandSide == ControllerHand.Right)
        {
            rightHand = grabber;
            Debug.Log("You just grabbed the scooter");
        }
    }

    public override void OnRelease()
    {
        if (rightHand.HeldGrabbable != this.grab)
        {
            rightHand = null;
            Debug.Log("You just released the scooter");
        }
    }

    public void Update()
    {
        speed = 0;
        //if (rightHand != null)
        //{
        //    speed = 5;
        //}

        //if (speed != 0)
        //{
        //    transform.Rotate(transform.up, Time.deltaTime);
        //    transform.position += transform.forward * speed * Time.deltaTime;
        //}
        MoveScooterForward(speed);
    }

    void MoveScooterForward(float speed)
    {
        if (rightHand)
        {
            speed = 5;
            transform.position += transform.forward * speed * Time.deltaTime;

        }
        //rb.AddForce(transform.forward * force, ForceMode.Acceleration);
        // if (driftingEffect != null && !driftingEffect.isPlaying)
        // {
        //     driftingEffect.Play();
        // }
    }

}
