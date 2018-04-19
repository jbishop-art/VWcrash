using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashCam : MonoBehaviour 
{
	public float xCenter = 0;
	public float xOffsetLeft;
	public float xOffsetRight;
	public float cameraDistance;
	public float cameraHeight;
	public float dampTime = 0.15f;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		float y = Player.CurrentPlayer.transform.position.y + cameraHeight;  // Ccamera a bit heigher than the character.  Or -2, depends on from side you want to look.
		float z = Player.CurrentPlayer.transform.position.z - cameraDistance;  // Distance between character and camera.

		if (Player.CurrentPlayer.transform.position.x > 2.5)
		{
			Vector3 destination = new Vector3 (xOffsetRight, y, z);
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
		else if (Player.CurrentPlayer.transform.position.x < -2.5)
		{
			Vector3 destination = new Vector3 (xOffsetLeft, y, z);
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}
		else 
		{
			Vector3 destination = new Vector3 (xCenter, y, z);
			transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
		}

		//transform.position = new Vector3 (xCenter, y, z);
		transform.rotation = new Quaternion(0, 0, 0, 0);  //rotate around y-Axis to at player.

	}
}
