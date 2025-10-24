// using BNG;
// using UnityEngine;

// public class Scooter : GrabbableEvents
// {
//     public float speed = 5f;
//     public SteeringWheel steering;

//     public Transform throttleReference;

//     private bool isHeld;

//     private Grabber rightHand;
//     public InputBridge bridge;

//     public override void OnGrab(Grabber grabber)
//     {
//         if (grabber.HandSide == ControllerHand.Right)
//         {
//             rightHand = grabber;
//         }
//     }

//     public override void OnRelease()
//     {
//         if (rightHand.HeldGrabbable != this.grab)
//         { 
//             rightHand = null;
//             brake = 0;
//         }
//     }

//     public void OnGrabScooter()
//     {
//         isHeld = true;
//     }

//     public void OnReleaseScooter()
//     {
//         isHeld = false;
//     }
//     float brake = 0; // -> 1
//     public void Update()
//     {
//         float speed = 0;

//         if (rightHand != null)
//         {
//             float maxAngle = 45;
//             float speedPercentage = Mathf.Clamp(0, 1, WristAngle(throttleReference.rotation, rightHand.transform.rotation) / maxAngle);

//             speed = speedPercentage * maxSpeed;

//             Debug.Log(speed);
//             speed = speedPercentage * this.speed;

//             brake = bridge.RightTrigger;

//             Debug.Log(speedPercentage);
//         }

//         if (speed != 0)
//         {
//             transform.Rotate(transform.up, -steering.Angle * Time.deltaTime);
//             transform.position += transform.forward * (speed * (1 - brake)) * Time.deltaTime;
//         }
//     }

//     public float WristAngle(Quaternion defaultRotation, Quaternion hand)
//     {
//         Vector3 defaultDirection = defaultRotation * Vector3.forward;
//         Vector3 flatWallNormal = defaultRotation * Vector3.right;
//         Vector3 handDirection = Vector3.ProjectOnPlane(hand * Vector3.forward, flatWallNormal);

//         return Vector3.SignedAngle(defaultDirection, handDirection, -flatWallNormal); // will return -180 -> 180, should clamp to a normal range
//     }
// }
