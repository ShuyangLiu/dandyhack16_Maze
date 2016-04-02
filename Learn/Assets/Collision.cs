using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
	
	}

    private bool IsHand(Collider other)
    {
        if (other.transform.parent && other.transform.parent.parent && other.transform.parent.parent.GetComponent<Leap.Unity.HandModel>())
            return true;
        else
            return false;
    }

    //Triggers first
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.gameObject.name);
        Debug.Log("Collided?");
        if (IsHand(collision))
        {
            Debug.Log("Yay! A hand collided!");
        }
    }

    void onCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    // Update is called once per frame
    void Update ()
    {
	
	}
}
