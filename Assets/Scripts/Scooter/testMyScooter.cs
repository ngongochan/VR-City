// TestMyScooter.cs

using BNG;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

// should work

public class TestMyScooter : GrabbableEvents
{
    public float force = 5f;
    public float steeringForce;
    public SteeringWheel steering;
    private Grabber rightHand, leftHand;
    public ParticleSystem driftingEffect;
    Rigidbody rb;
    public AudioClip honkAudioClip;
    public Light drivingLight;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

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

    public void FixedUpdate()
    {
        MoveScooterForward();
        Steer();
        // else
        // {
        //     StopScooter();
        // }
    }

    void MoveScooterForward()
    {
        if (rightHand)
        {
            rb.AddForce(transform.forward * force, ForceMode.Acceleration);
        }
        // if (driftingEffect && !driftingEffect.isPlaying)
        // {
        //     driftingEffect.Play();
        // }
    }
    void Steer()
    {
        Quaternion steeringAngle = Quaternion.Euler(Vector3.up * steeringForce * Time.DeltaTime);
        rb.MoveRotation(rb.rotation * steeringAngle);
    }
}
