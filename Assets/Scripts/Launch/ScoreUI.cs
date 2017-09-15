using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public PlayerMove Player;

    public int Score = 0;
    public Text ScoreText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Score = (int)Player.transform.position.z;
	    ScoreText.text = "Distance: " + Score.ToString().PadLeft(6, '0');
	}
}
