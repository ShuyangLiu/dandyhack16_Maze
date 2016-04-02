using UnityEngine;
using System.Collections;
using Leap;

public class test : MonoBehaviour {
    Controller controller;

	// Use this for initialization
	void Start () {
        controller = new Controller();
	}
	
	// Update is called once per frame
	void Update () {
       Leap.Unity.IHandModel _handModel;
       _handModel = GetComponentInParent<IHandModel>()
       Debug.Log(_handModel.ToString);
	}
}
