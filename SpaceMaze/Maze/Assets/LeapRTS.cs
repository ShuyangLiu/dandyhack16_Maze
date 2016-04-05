using UnityEngine;
using System.Collections;

namespace Leap.Unity.PinchUtility {

  /// <summary>
  /// Use this component on a Game Object to allow it to be manipulated by a pinch gesture.  The component
  /// allows rotation, translation, and scale of the object (RTS).
  /// </summary>
  public class LeapRTS : MonoBehaviour{

    public enum RotationMethod {
      None,
      Single,
      Full
    }

    [SerializeField]
    private LeapPinchDetector _pinchDetectorA;

    [SerializeField]
    private LeapPinchDetector _pinchDetectorB;

    [SerializeField]
    private RotationMethod _oneHandedRotationMethod;

    [SerializeField]
    private RotationMethod _twoHandedRotationMethod;

    [SerializeField]
    private bool _allowScale = true;

    [Header("GUI Options")]
    [SerializeField]
    private KeyCode _toggleGuiState = KeyCode.None;

    [SerializeField]
    private bool _showGUI = true;

    private Transform _anchor;

    private float _defaultNearClip;

    private HandModel[] target_obj;
    private bool collided = false;
	bool startPinch = true;
	Vector3 startDistance = Vector3.zero;
    
   void Start()
	{
        target_obj = new HandModel[16];
        for (int i = 0; i < target_obj.Length; i++)
        {
            target_obj[i] = null;
        }
    }

    private HandModel IsHand(Collider other)
    {
        if (other.transform.parent && other.transform.parent.parent && other.transform.parent.parent.GetComponent<Leap.Unity.HandModel>())
            return other.transform.parent.parent.GetComponent<HandModel>();
        else
            return null;
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("WAT");
        for (int i = 0; i < target_obj.Length; i++)
        {
            if (target_obj[i] == null)
            {
                target_obj[i] = IsHand(collider);
                break;
            }
        }
        
        foreach (HandModel model in target_obj)
        {
            if (model != null)
            {
                collided = true;
                break;
            }
        }
			
    }

    void OnTriggerExit(Collider collider)
    {
        //Debug.Log("WE FUCKING LOST");
        for (int i = 0; i < target_obj.Length; i++)
        {
            if (target_obj[i] != null)
            {
                target_obj[i] = null;
                break;
            }
        }
    }

    void Awake()
	{
		if (_pinchDetectorA == null || _pinchDetectorB == null)
		{
        	Debug.LogWarning("Both Pinch Detectors of the LeapRTS component must be assigned. This component has been disabled.");
        	enabled = false;
      	}

	    GameObject pinchControl = new GameObject("RTS Anchor");
		_anchor = pinchControl.transform;
	    _anchor.transform.parent = transform.parent;
	    transform.parent = _anchor;
    }

    void Update()
	{
      if (Input.GetKeyDown(_toggleGuiState)) {
        _showGUI = !_showGUI;
      }

      if (collided)
      {
			if (_pinchDetectorA.DidStartPinch)
				startDistance = _pinchDetectorA.Position;
			else if (_pinchDetectorB.DidStartPinch)
				startDistance = _pinchDetectorB.Position;
            //Debug.Log("Hand in collision");
            bool didUpdate = false;
            didUpdate |= _pinchDetectorA.DidChangeFromLastFrame;
            didUpdate |= _pinchDetectorB.DidChangeFromLastFrame;

            if (didUpdate)
            {
                transform.SetParent(null, true);
            }

            /*if (_pinchDetectorA.IsPinching && _pinchDetectorB.IsPinching)
            {
                transformDoubleAnchor();
            }*/
			
            if (_pinchDetectorA.IsPinching)
            {
                transformSingleAnchor(_pinchDetectorA);
            }
            else if (_pinchDetectorB.IsPinching)
            {
                transformSingleAnchor(_pinchDetectorB);
            }
			
			if (_pinchDetectorA.DidEndPinch || _pinchDetectorB.DidEndPinch)
			{
				Debug.Log ("Force Added");
				Debug.Log (startDistance);
				Debug.Log (_pinchDetectorA.Position);
                
				//this.GetComponent<Rigidbody>().useGravity = true;
				this.GetComponent<Rigidbody>().AddForce((_anchor.position - startDistance) * 10, ForceMode.Impulse);
				//this.GetComponent<Rigidbody> ().useGravity = true;
				//this.GetComponent<BoxCollider> ().isTrigger = false;
				//_anchor.FindChild("RTS Anchor").FindChild("MengerSponge").GetComponent<Rigidbody>().useGravity = true;
				//this.GetComponent<Rigidbody>().AddForce(1000 * distance);
				//gameObject.rigidbody.AddForce(10, ForceMode.Impulse);
			}
			
            if (didUpdate)
            {
                transform.SetParent(_anchor, true);
            }
					

            bool lever = false;
            foreach (HandModel model in target_obj)
            {
                if (model != null)
                {
                    //Debug.Log(model.fingers);
                    lever = true;
                    break;
                }
            }
            if (!lever)
                collided = false;
        }
    }

    void OnGUI() {
      if (_showGUI) {
        GUILayout.Label("One Handed Settings");
        doRotationMethodGUI(ref _oneHandedRotationMethod);
        GUILayout.Label("Two Handed Settings");
        doRotationMethodGUI(ref _twoHandedRotationMethod);
        _allowScale = GUILayout.Toggle(_allowScale, "Allow Two Handed Scale");
      }
    }

    private void doRotationMethodGUI(ref RotationMethod rotationMethod) {
      GUILayout.BeginHorizontal();

      GUI.color = rotationMethod == RotationMethod.None ? Color.green : Color.white;
      if (GUILayout.Button("No Rotation")) {
        rotationMethod = RotationMethod.None;
      }

      GUI.color = rotationMethod == RotationMethod.Single ? Color.green : Color.white;
      if (GUILayout.Button("Single Axis")) {
        rotationMethod = RotationMethod.Single;
      }

      GUI.color = rotationMethod == RotationMethod.Full ? Color.green : Color.white;
      if (GUILayout.Button("Full Rotation")) {
        rotationMethod = RotationMethod.Full;
      }

      GUI.color = Color.white;

      GUILayout.EndHorizontal();
    }

//    private void transformDoubleAnchor() {
//      _anchor.position = (_pinchDetectorA.Position + _pinchDetectorB.Position) / 2.0f;
//
//      switch (_twoHandedRotationMethod) {
//        case RotationMethod.None:
//          break;
//        case RotationMethod.Single:
//          Vector3 p = _pinchDetectorA.Position;
//          p.y = _anchor.position.y;
//          _anchor.LookAt(p);
//          break;
//        case RotationMethod.Full:
//          Quaternion pp = Quaternion.Lerp(_pinchDetectorA.Rotation, _pinchDetectorB.Rotation, 0.5f);
//          Vector3 u = pp * Vector3.up;
//          _anchor.LookAt(_pinchDetectorA.Position, u);
//          break;
//      }
//
//      if (_allowScale) {
//        _anchor.localScale = Vector3.one * Vector3.Distance(_pinchDetectorA.Position, _pinchDetectorB.Position);
//      }
//    }

    private void transformSingleAnchor(LeapPinchDetector singlePinch)
	{
		_anchor.position = singlePinch.Position;

		switch (_oneHandedRotationMethod)
		{
			case RotationMethod.None:
			break;
			case RotationMethod.Single:
				Vector3 p = singlePinch.Rotation * Vector3.right;
				p.y = _anchor.position.y;
				_anchor.LookAt(p);
				break;
			case RotationMethod.Full:
				_anchor.rotation = singlePinch.Rotation;
				break;
  		}

		_anchor.localScale = Vector3.one;
    }
  }
}
