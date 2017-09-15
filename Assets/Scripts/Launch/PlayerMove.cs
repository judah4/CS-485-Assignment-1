using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    public int jumpCount = 1;
    public int maxJump = 1;
    public float JumpStrength = 10;
    public float MoveStrength = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _rigidbody.AddForce(input * MoveStrength);

	    if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
	    {
	        jumpCount--;
            _rigidbody.AddForce(Vector3.up * JumpStrength, ForceMode.Impulse);
	    }
    }
}
