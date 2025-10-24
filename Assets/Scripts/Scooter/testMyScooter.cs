using BNG;
using UnityEngine;
using UnityEngine.InputSystem.Utilities;

// made some changes to Matt's scripts

[DefaultExecutionOrder(-1000)]
public class testMyScooter : GrabbableEvents
{
    public Transform root;
    public AnimationCurve turningGraph;

    public float maxSpeed = 5;
    public SteeringWheel steering;
    private Grabber rightHand;

    public Transform rayTransform;

    Rigidbody rb;

    public AudioClip honkAudioClip;

    public Light drivingLight;


    public float velocity;
    public float acceleration;

    private void Awake()
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
        if (rightHand.HeldGrabbable == this.grab)
        {
            rightHand = null;
            Debug.Log("You just released the scooter");
        }
    }

    public void Update()
    {
        /*if (rayTransform)
        {
            Ray ray = new Ray(rayTransform.position, rayTransform.forward);

            if (Physics.Raycast(ray, out var hit, 10))
            {
                Debug.DrawLine(ray.origin, hit.point);
            }
        }*/

        
        if (rightHand != null)
        {
            velocity += acceleration * Time.deltaTime;
            velocity = Mathf.Clamp(velocity, 0, maxSpeed = 5);
        }
        else
        {
            velocity -= acceleration * Time.deltaTime;
            velocity = Mathf.Clamp(velocity, 0, maxSpeed = 5);
        }

        if (velocity >= 0)
        {
            //rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
            //rb.MoveRotation(Quaternion.AngleAxis(Time.deltaTime, transform.up) * rb.rotation);

            root.Rotate(root.up, -steering.Angle * turningGraph.Evaluate(velocity) * Time.deltaTime);
            root.position += root.forward * velocity * Time.deltaTime;
        }
    }

    void MoveScooterForward()
    {
        if (rightHand)
        {
            root.position += transform.forward * velocity * Time.deltaTime;
        }
        //rb.AddForce(transform.forward * force, ForceMode.Acceleration);
    }

}
