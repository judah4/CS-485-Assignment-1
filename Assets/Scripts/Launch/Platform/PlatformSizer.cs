using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSizer : MonoBehaviour
{
    private int lastSize = 0;
    public int Level = 1;
    public float SizeAdd = 1;
    public float offset = 5f;
    public PlatformStart StartPlatform;

	// Use this for initialization
	void Start ()
	{
	    Level = PlayerPrefs.GetInt("Platform Length", 1);
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3(1, 1, Level + SizeAdd);
        transform.localPosition = Vector3.forward * -(Level+SizeAdd)*offset;
	    StartPlatform.transform.localPosition = Vector3.forward * -(Level + SizeAdd ) * 2 * offset;
	    if (lastSize != Level)
	    {
	        lastSize = Level;
	        StartPlatform.Resize();
	    }
	}
}
