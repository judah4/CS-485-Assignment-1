using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerMove : MonoBehaviour
{
    [SerializeField]
    private Rigidbody _rigidbody;

    public int jumpCount = 1;
    public int maxJump = 1;
    public float JumpStrength = 10;
    public float MoveStrength = 10;

    public Camera cam;
    public MouseLook mouseLook = new MouseLook();

	// Use this for initialization
	void Start () {
		mouseLook.Init (transform, cam.transform);

	}

    private void Update()
    {
        RotateView();
    }

    // Update is called once per frame
	void FixedUpdate () {
        
		var input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _rigidbody.AddForce(transform.TransformDirection(input) * MoveStrength);

	    if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
	    {
	        jumpCount--;
            _rigidbody.AddForce(Vector3.up * JumpStrength, ForceMode.Impulse);
	    }
    }

    private void RotateView()
    {
        //avoids the mouse looking if the game is effectively paused
        if (Mathf.Abs(Time.timeScale) < float.Epsilon) return;

        // get the rotation before it's changed
        float oldYRotation = transform.eulerAngles.y;

        mouseLook.LookRotation (transform, cam.transform);

            // Rotate the rigidbody velocity to match the new direction that the character is looking
            //Quaternion velRotation = Quaternion.AngleAxis(transform.eulerAngles.y - oldYRotation, Vector3.up);
            //_rigidbody.velocity = velRotation*_rigidbody.velocity;
            
    }

}
