using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformStart : MonoBehaviour
{

    public GameObject SpawnPosition;
    public PlayerMove PlayerController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Resize()
    {
        PlayerController.transform.position = SpawnPosition.transform.position;
        
    }
}
