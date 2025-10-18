# Trash Bin Collision Sound
TrashBinRoot (Rigidbody, Script, AudioSource)

<pre>
├── TrashBin (all the visuals from my models + their textures, this object itself is an empty object)
│   	├──  TrashBinBody (Mesh Renderer = true)
│   	├──  TrashBinLid (Mesh Renderer = true)		
│   	├──  … (also Mesh Renderer = true)	
│   	└── TrashBinWheels (Mesh Renderer = true)	
└── TrashBinColliders (for colliders only, Box Colliders preferred)	
	├──  Cube (Box Collider = true, Mesh Renderer = false)
	├──  Cube (1) (Box Collider = true, Mesh Renderer = false)
	├──  … (also Box Collider = true, Mesh Renderer = false)
	└── Cube (n) (Box Collider = true, Mesh Renderer = false)
</pre>

For these collider cubes, only change the Size of the Box Collider, not the Mesh (cube) itself!

Drag the audio clip onto the Trash Bin Collision Sound  part of the TrashBinSound.cs (Script).