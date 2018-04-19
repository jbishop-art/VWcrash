using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody rb;

	public Vector3 jump;
	public float jumpforce;

	public bool isGrounded;
	private float prevPosY;
	private float newPosY;
	private float movementY;
	private float moveResultY;
	private float fwdY;

	public bool canSpin;


	// Use this for initialization
	void Start ()
    {
		rb = GetComponent<Rigidbody>();
		jump = new Vector3(0.0f, 2.0f, 0.0f);
	}

	void OnCollisionStay()
	{
		isGrounded = true;
		canSpin = true;
	}
	
	// Update is called once per frame
	void FixedUpdate()
    {		
        transform.Translate(speed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, speed * Input.GetAxis("Vertical") * Time.deltaTime);

		
	}

	void Update()
	{
		newPosY = transform.position.y;
		movementY = (newPosY - prevPosY);

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
		{
			isGrounded = false;
			rb.AddForce(jump * jumpforce, ForceMode.Impulse);
		}

		if (Input.GetKeyDown(KeyCode.Return) && canSpin)
		{
			canSpin = false;
			//StartCoroutine("rotateSpin");
		}
	}

	void LateUpdate()
	{
		prevPosY = transform.position.y;
		fwdY = transform.up.y;
	}

	// IEnumerator rotateSpin()
	// {

	// 	// transform.Rotate(Vector3.up, 120.0f);
	// 	// yield return new WaitForSeconds(0.1f);
	// 	// transform.Rotate(Vector3.up, 120.0f);
	// 	// yield return new WaitForSeconds(0.1f);
	// 	// transform.Rotate(Vector3.up, 120.0f);
	// }
}
