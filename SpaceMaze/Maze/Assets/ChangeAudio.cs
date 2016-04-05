using UnityEngine;
using System.Collections;
using System.Timers;
public class ChangeAudio : MonoBehaviour {
    AudioSource audio;
    float time;
	// Use this for initialization
	void Start () {
        audio = GetComponent<AudioSource>();
        time = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        time = Time.time;
        //GameObject.FindGameObjectWithTag("New Text"). = time;
	}
}
