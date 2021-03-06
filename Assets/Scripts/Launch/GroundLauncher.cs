﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLauncher : MonoBehaviour
{

    public float force = 3;
    private float startingForce;

	// Use this for initialization
	void Start ()
	{
	    startingForce = force;
	    force = PlayerPrefs.GetInt("Launch Speed", 1) * startingForce;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
    } 

    protected void OnTriggerStay(Collider other)
    {
        //Debug.Log("Stay:" +other.gameObject.name);

        if(other.attachedRigidbody == null)
            return;

        var forces = (transform.forward.normalized * 3);
        Debug.Log(forces);
        forces = transform.TransformDirection(forces);
        other.attachedRigidbody.AddForce(forces);
    } 

}
