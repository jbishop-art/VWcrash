using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong : MonoBehaviour
{
    private bool dirRight = true;
    public float speed = 2.0f;
    public float distance = 4.0f;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (dirRight)
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate(-Vector2.right * speed * Time.deltaTime);

        if (transform.position.x >= distance)
        {
            dirRight = false;
        }

        if (transform.position.x <= (distance * (-1)))
        {
            dirRight = true;
        }
    }
}
