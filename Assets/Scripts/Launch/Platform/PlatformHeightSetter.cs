using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformHeightSetter : MonoBehaviour
{

    public int Level = 1;
    public float HeightAdjust = 5;
    public float StartHeight = 1;

	// Use this for initialization
	void Start () {
		Level = PlayerPrefs.GetInt("Platform Height", 1);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector3.up * (StartHeight + Level * HeightAdjust);
	}
}
