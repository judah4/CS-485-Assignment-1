using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundStick : MonoBehaviour
{
    [SerializeField]
    private GameManager _gameManager;

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody == null)
            return;

        collision.rigidbody.drag = 100;

        if (collision.gameObject.tag == "Player")
        {
            _gameManager.Player.SoundManager.PlayClip(1);
            _gameManager.ChangeState(GameState.End);
        }
        
    }
}
