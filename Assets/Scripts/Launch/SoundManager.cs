using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource JetpackAudio;
    public AudioSource MainPlayer;

    public AudioClip[] Clips;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ToggleJetpack(bool on)
    {
        if (on && JetpackAudio.isPlaying == false)
        {
            JetpackAudio.Play();
        }
        else if(!on && JetpackAudio.isPlaying)
        {
            JetpackAudio.Stop();
        }
    }

    public void PlayClip(int clipId)
    {
        MainPlayer.clip = Clips[clipId];
        MainPlayer.Play();
    }

}
