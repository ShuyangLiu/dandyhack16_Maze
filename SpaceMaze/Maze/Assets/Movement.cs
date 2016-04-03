using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    float speed = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 movement = Vector3.zero;

        if (Input.GetKey("w"))
        {
            Vector3 a= Camera.main.transform.forward;
            a.y = 0;
            movement += a;
        }
        if (Input.GetKey("s"))
        {
            Vector3 a = Camera.main.transform.forward;
            a.y = 0;
            movement += -1 * a;
        }
        if (Input.GetKey("a"))
        {
            Vector3 a = Camera.main.transform.right;
            a.y = 0;
            movement += -1 * a;
        }
        if (Input.GetKey("d"))
        {
            Vector3 a = Camera.main.transform.right;
            a.y = 0;
            movement += a;
        }

        transform.Translate(movement * speed * Time.deltaTime, Space.Self);
	}
}
