// using BNG;
// using UnityEngine;

// // SteeringWheel Vertical
// // Matt's Scripts
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
//             float speedPercentage = WristAngle(throttleReference.rotation, rightHand.transform.rotation) / 180f;
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

//     public float WristAngle(Quaternion reference, Quaternion hand)
//     {
//         Vector3 handForward = Vector3.ProjectOnPlane(hand * Vector3.forward, reference * Vector3.right);
//         return Vector3.SignedAngle(reference * Vector3.forward, handForward, reference * -Vector3.right);
//     }
// }
