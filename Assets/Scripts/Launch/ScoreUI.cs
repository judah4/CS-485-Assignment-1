using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public PlayerMove Player;
    public GameManager GameManager;

    
    public Text ScoreText;

	// Use this for initialization
	void Start ()
	{
	    GameManager.OnChange += OnChange;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    if (GameManager.GameState == GameState.Play)
	    {
	        GameManager.Score = (int) Player.transform.position.z;
	        ScoreText.text = "Distance: " + GameManager.Score.ToString().PadLeft(6, '0');
	    }
	}

    void OnChange(GameState state)
    {
        if (state == GameState.End)
        {
            //Show game over
            Debug.Log("Game Over!");
        }

        
    }
}
