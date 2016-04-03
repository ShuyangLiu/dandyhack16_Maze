using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {

    

    public float turnSpeed = 4.0f;
    public float panSpeed = 4.0f;
    public float zoomSpeed = 4.0f;

    float distance = 6;
    //Vector3 lastPosition;

    // Use this for initialization
    void Start()
    {
        //lastPosition = gameObject.transform.position;
        //Debug.Log("Start ran");
    }

    /*void OnTriggerEnter(Collider other)
    {
        gameObject.transform.position = lastPosition;
        Debug.Log("triggered.");
    }*/

    void Update()
    {
        //lastPosition = gameObject.transform.position;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 position = this.transform.position;
            Vector3 cam = Camera.main.transform.right;
            cam.y = 0;
            position = transform.position + cam * -distance * Time.deltaTime; ;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 position = this.transform.position;
            Vector3 cam = Camera.main.transform.right;
            cam.y = 0;
            position = transform.position + cam * distance * Time.deltaTime; ;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 position = this.transform.position;
            Vector3 cam = Camera.main.transform.forward;
            cam.y = 0;
            position = transform.position + cam * distance * Time.deltaTime;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 position = this.transform.position;
            Vector3 cam = Camera.main.transform.forward;
            cam.y = 0;
            position = transform.position + cam * -distance * Time.deltaTime;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 position = this.transform.position;
            Vector3 cam = Camera.main.transform.right;
            cam.y = 0;
            position = transform.position + cam * -distance * Time.deltaTime; ;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 position = this.transform.position;
            Vector3 cam = Camera.main.transform.right;
            cam.y = 0;
            position = transform.position + cam * distance * Time.deltaTime; ;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 position = this.transform.position;
            Vector3 cam = Camera.main.transform.forward;
            cam.y = 0;
            position = transform.position + cam * distance * Time.deltaTime;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 position = this.transform.position;
            Vector3 cam = Camera.main.transform.forward;
            cam.y = 0;
            position = transform.position + cam * -distance * Time.deltaTime;
            this.transform.position = position;
        }

        /*// Get the left mouse button
        if (Input.GetMouseButtonDown(0))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }

        // Get the right mouse button
        if (Input.GetMouseButtonDown(1))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isPanning = true;
        }

        // Get the middle mouse button
        if (Input.GetMouseButtonDown(2))
        {
            // Get mouse origin
            mouseOrigin = Input.mousePosition;
            isZooming = true;
        }

        // Disable movements on button release
        if (!Input.GetMouseButton(0)) isRotating = false;
        if (!Input.GetMouseButton(1)) isPanning = false;
        if (!Input.GetMouseButton(2)) isZooming = false;

        // Rotate camera along X and Y axis
        if (isRotating)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
            transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
        }

        // Move the camera on it's XY plane
        if (isPanning)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
            transform.Translate(move, Space.Self);
        }

        // Move the camera linearly along Z axis
        if (isZooming)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = pos.y * zoomSpeed * transform.forward;
            transform.Translate(move, Space.World);
        }
    }*/
    }
}
