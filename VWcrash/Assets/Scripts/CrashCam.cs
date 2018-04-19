using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashCam : MonoBehaviour 
{
	public float xCenter = 0;
	public float xOffsetLeft;
	public float xOffsetRight;
	public float cameraDistance;
	public float cameraDistanceOffset;
	public float cameraHeight;
	public float dampTimeForward = 0.15f;
	public float dampTimeBackward = 0.15f;
	private float z;
	private Vector3 velocity = Vector3.zero;

	private float movement;
	private float prevPos;
	private float newPos;
	//private float fwd;
	private float moveResult;
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float y = Player.CurrentPlayer.transform.position.y + cameraHeight;  // Camera a bit heigher than the character.  
		
		newPos = (Mathf.Round(Player.CurrentPlayer.transform.position.z * 10) / 10);
		movement = (newPos - prevPos);
		
		Debug.Log(movement);

		if (movement < 0)  // Checks to see if player is moving toward camera.
		{
			z = Player.CurrentPlayer.transform.position.z - (cameraDistance + cameraDistanceOffset);  // Distance between character and camera  will be offset.

			if (Player.CurrentPlayer.transform.position.x > 2.5) //player going Right.
			{
				Vector3 destination = new Vector3 (xOffsetRight, y, z);
				transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTimeBackward);
			}
			else if (Player.CurrentPlayer.transform.position.x < -2.5) //Player going Left.
			{
				Vector3 destination = new Vector3 (xOffsetLeft, y, z);
				transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTimeBackward);
			}
			else //Player is in Center.
			{
				Vector3 destination = new Vector3 (xCenter, y, z);
				transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTimeBackward);
			}
		}
		else // Player is moving away from camera.
		{
			z = Player.CurrentPlayer.transform.position.z - cameraDistance ; // Player and camera distance will be normal.

			if (Player.CurrentPlayer.transform.position.x > 2.5) //Player going Right.
			{
				Vector3 destination = new Vector3 (xOffsetRight, y, z);
				transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTimeForward);
			}
			else if (Player.CurrentPlayer.transform.position.x < -2.5)  //Player going Left.
			{
				Vector3 destination = new Vector3 (xOffsetLeft, y, z);
				transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTimeForward);
			}
			else //Player is in Center.
			{
				Vector3 destination = new Vector3 (xCenter, y, z);
				transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTimeForward);
			}
		}

		transform.rotation = new Quaternion(0, 0, 0, 0);  //Camer look at player.

	}

	void LateUpdate()
	{
		prevPos = (Mathf.Round(Player.CurrentPlayer.transform.position.z * 10) / 10);
		//fwd = Player.CurrentPlayer.transform.forward.z;
	}
}
