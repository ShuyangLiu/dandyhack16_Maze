using UnityEngine;
using System.Collections;

public class Gavity : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Rigidbody body = GetComponent<Rigidbody>();

        if (Input.GetKeyUp("g"))
        {
            if (body.velocity == Vector3.zero)
                body.AddForce(Physics.gravity);
            else
            {
                Debug.Log("Velocity y: " + body.velocity.y);
                if (body.velocity.y < 0)
                    body.AddForce(Physics.gravity * -2);
                else
                    body.AddForce(Physics.gravity * 2);
            }
        }
	}
}
