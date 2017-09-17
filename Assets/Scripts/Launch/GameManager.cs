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

    public List<GroundStick> Grounds;
    //public float LastGroundPos = 0;
    //public float LastGroundPosLeft = 0;
    //public float LastGroundPosRight = 0;
	// Use this for initialization
	void Start () {
		Money = PlayerPrefs.GetInt("Money", 0);
	}
	
	// Update is called once per frame
	void Update () {
	    //if (Player.transform.position.z > LastGroundPos)
	    //{
	    //    var instanGround = Instantiate(Grounds[0]);
     //       Grounds.Add(instanGround);
     //       instanGround.transform.position = Vector3.forward * (LastGroundPos + 1000);
	    //    LastGroundPos = instanGround.transform.position.z;
	    //}
     //   if (Player.transform.position.x > LastGroundPosRight)
	    //{
	    //    var instanGround = Instantiate(Grounds[0]);
     //       Grounds.Add(instanGround);
     //       instanGround.transform.position = Vector3.forward * (LastGroundPos) + Vector3.right * (LastGroundPosRight + 1000);
	    //    LastGroundPosRight = instanGround.transform.position.x;
	    //}
     //   if (Player.transform.position.x < LastGroundPosLeft)
	    //{
	    //    var instanGround = Instantiate(Grounds[0]);
     //       Grounds.Add(instanGround);
     //       instanGround.transform.position = Vector3.forward * (LastGroundPos) + Vector3.right * (LastGroundPosLeft - 1000);
	    //    LastGroundPosLeft = instanGround.transform.position.x;
	    //}
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
