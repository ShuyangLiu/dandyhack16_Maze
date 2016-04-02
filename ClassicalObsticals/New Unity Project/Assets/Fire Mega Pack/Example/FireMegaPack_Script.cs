using UnityEngine;
using System.Collections;

public class FireMegaPack_Script : MonoBehaviour {

	public GameObject[] Fire;
	private int FilterCount;
	private int FilterTotal;
    private GameObject myFire;

    float timeLeft = 0;
    float timeLeft2 = 0;

    public Renderer rend;

    void Start () 
	{
		FilterTotal = Fire.Length;
        myFire = GetComponent<GameObject>();

        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }
	
	void Awake () 
	{

	}



	void TurnOffAll()
	{
		for (int a=0; a<Fire.Length; a++)
		{
			Fire[a].SetActive(false);
		}
	}

	void Change_Filters()
	{
		TurnOffAll ();
		if (FilterCount > FilterTotal-1) FilterCount = 0;
		if (FilterCount < 0) FilterCount = FilterTotal-1;
		Fire[FilterCount].SetActive(true);
	}

	void Update () 
	{

        // Find out whether current second is odd or even
        bool oddeven = Mathf.FloorToInt(Time.time) % 3 == 0;

        // Enable renderer accordingly
        rend.enabled = oddeven;
      
	}
	
	
	
	void OnGUI()
	{
		
        if(timeLeft > 0)
        {
            GUI.Label(new Rect(100, 100, 200, 100), "Time Remaining : " + (int)System.Math.Ceiling(timeLeft));
        }

     
		Vector2 Scr = new Vector2((float)Screen.width/1280.0f,(float)Screen.height/720.0f);
		Vector4 Pos;
		
		Pos = new Vector4 (280, 0, 1000-280, 60);	
		if (GUI.Button (new Rect (Pos.x*Scr.x, Pos.y*Scr.y, Pos.z*Scr.x, Pos.w*Scr.y), FilterCount.ToString()+" / "+FilterTotal.ToString()+" = "+ Fire[FilterCount].name)) 
		{

		}
		
		Pos = new Vector4 (0, 0, 280, 60);
		if (GUI.Button (new Rect (Pos.x*Scr.x, Pos.y*Scr.y, Pos.z*Scr.x, Pos.w*Scr.y), " Preview ")) 
		{
			FilterCount--;
			Change_Filters();
		}
		
		Pos = new Vector4 (1000, 0, 280, 60);
		if (GUI.Button (new Rect (Pos.x*Scr.x, Pos.y*Scr.y, Pos.z*Scr.x, Pos.w*Scr.y), " Next ")) 
		{
			FilterCount++;
			Change_Filters();
		}
		
		Pos = new Vector4 (0, 60, 360, 60);
		if (GUI.Button (new Rect (Pos.x*Scr.x, Pos.y*Scr.y, Pos.z*Scr.x, Pos.w*Scr.y), " Pause (Amazing Pause)")) 
		{
			Fire[FilterCount].GetComponent<ParticleSystem>().Pause(true);
			}
		
		Pos = new Vector4 (0, 120, 360, 60);
		if (GUI.Button (new Rect (Pos.x*Scr.x, Pos.y*Scr.y, Pos.z*Scr.x, Pos.w*Scr.y), " Play ")) 
		{
			Fire[FilterCount].GetComponent<ParticleSystem>().Play (true);
		}

	}
}
