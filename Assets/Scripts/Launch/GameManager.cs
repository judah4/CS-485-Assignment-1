using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    private GameState _gameState = GameState.Play;
    public GameState GameState { get { return _gameState; } }

    public PlayerMove Player;
    public int Score = 0;
    public int Money = 0;

    public event Action<GameState> OnChange;
	// Use this for initialization
	void Start () {
		Money = PlayerPrefs.GetInt("Money", 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeState(GameState gameState)
    {
        _gameState = gameState;
        if (OnChange != null)
            OnChange(_gameState);
    }

    public void UpdateMoney()
    {
        Money += Score;
        PlayerPrefs.SetInt("Money", Money);
    }
}

public enum GameState
{
    Ready,
    Play,
    End,
}
