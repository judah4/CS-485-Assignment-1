using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed;
    public float JumpPower = 10;

    private Rigidbody rb;

    public event Action<int> OnScore;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

        rb.AddForce (movement * (speed * rb.mass));

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * JumpPower*rb.mass, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            MassAndSizeIncrease();
        }
    }

    void MassAndSizeIncrease()
    {
        rb.mass++;
        transform.localScale = transform.localScale + Vector3.one;
    }
}
