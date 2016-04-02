using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    float speed = 10f;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey("w"))
            movement.z++;
        if (Input.GetKey("s"))
            movement.z--;
        if (Input.GetKey("a"))
            movement.x--;
        if (Input.GetKey("d"))
            movement.x++;
        if (Input.GetKey("q"))
            movement.y--;
        if (Input.GetKey("e"))
            movement.y++;
        transform.Translate(movement * speed * Time.deltaTime, Space.Self);
	}
}
