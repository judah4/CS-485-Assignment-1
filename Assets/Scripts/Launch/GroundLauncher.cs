using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLauncher : MonoBehaviour
{

    public float force = 3;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    protected void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
    } 

    protected void OnTriggerStay(Collider other)
    {
        Debug.Log("Stay:" +other.gameObject.name);

        if(other.attachedRigidbody == null)
            return;

        var forces = transform.forward.normalized * 3;
        Debug.Log(forces);

        other.attachedRigidbody.AddForce(forces);
    } 

}
