**There are two primary methods for using grabbable events:**
1. Using `GrabbableUnityEvents` component:
Add the `GrabbableUnityEvents` component to your `Grabbable` object. 
In the Inspector, you can drag public methods from other scripts into the event slots (e.g., "`On Grab`," "`On Drop`"). 

2. Extending the `GrabbableEvents` class:
Create a new script that inherits from `GrabbableEvents`. 
Override the desired virtual event methods, such as `virtual void OnGrab(Grabber grabber)`. 
This approach is useful for creating more complex custom behavior that goes beyond simple event responses. 