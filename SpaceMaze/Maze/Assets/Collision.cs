using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

    float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}

    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        this.transform.position = new Vector3(this.transform.position.x, 16.329f, this.transform.position.z);
        Debug.Log("HERE");
        Rigidbody body = hit.collider.attachedRigidbody;
        if (body == null || body.isKinematic)
            return;


    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey("left shift"))
        {
            speed = 5f;
        } else
        {
            speed = 10f;
        }
	    if (Input.GetKey("w"))
        {
            Vector3 move = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
            this.GetComponent<CharacterController>().Move(move / speed);
        }
        if (Input.GetKey("s"))
        {
            Vector3 move = -1 * new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
            this.GetComponent<CharacterController>().Move(move / speed);
        }
        if (Input.GetKey("a"))
        {
            Vector3 move = -1 * new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z);
            this.GetComponent<CharacterController>().Move(move / speed);
        }
        if (Input.GetKey("d"))
        {
            Vector3 move = new Vector3(Camera.main.transform.right.x, 0, Camera.main.transform.right.z);
            this.GetComponent<CharacterController>().Move(move / speed);
        }
	}
}
