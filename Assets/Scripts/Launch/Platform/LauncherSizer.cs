using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherSizer : MonoBehaviour {

	public int Level = 1;


	// Use this for initialization
	void Start () {
        Level = PlayerPrefs.GetInt("Ramp Length", 1);
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = new Vector3(1, 1, Level);
        //transform.position = transform.parent.position + (Vector3.forward * -Level*10);
	}
}
