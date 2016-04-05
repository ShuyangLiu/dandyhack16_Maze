using UnityEngine;
using System.Collections;

public class up : MonoBehaviour {

    AudioSource audio;
    bool isPlaying = false;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
	}

    float time = 0;
	
	// Update is called once per frame
	void Update () {
        this.transform.position.Set(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z);
        time += Time.deltaTime;
        if(time > 3)
        {
            if (!isPlaying)
            {
                isPlaying = true;   
                audio.Play();
            }
        } 

        if (time > 5)
        {
            //AutoFade.LoadLevel("MainFrame", 3, 1, Color.black);
            
        }
	    
	}
}
