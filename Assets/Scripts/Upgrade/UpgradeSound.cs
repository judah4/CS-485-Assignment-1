using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSound : MonoBehaviour
{

    public AudioSource Source;
    public AudioClip PosClip;
    public AudioClip NegClip;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayBlip(bool pos)
    {
        if (pos)
            Source.clip = PosClip;
        else
            Source.clip = NegClip;

        Source.Play();
    }
}
