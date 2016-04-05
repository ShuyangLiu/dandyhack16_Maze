using UnityEngine;
using System.Collections;

public class MoveTo : MonoBehaviour {
    bool moved;
    float time;
    // Use this for initialization
	void Start () {
        moved = false;
        time = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        time = Time.time;
        if (time > 10 && !moved)
        {
            this.transform.position = new Vector3(175.109f, 16.329f, -80.0f);
            moved = true;
        }
    }
}
