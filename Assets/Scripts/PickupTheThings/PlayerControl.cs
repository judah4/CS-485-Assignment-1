using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed;
    public float JumpPower = 10;

    public Transform Sphere;

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
        var torque = new Vector3(moveVertical,0,-moveHorizontal) * speed / 2;
        rb.AddForce (movement * (speed * rb.mass));
        rb.AddTorque(torque);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * JumpPower*rb.mass, ForceMode.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            MassAndSizeIncrease(1);
        }
    }

    public void AddPickup(Collider collider)
    {
        if (collider.attachedRigidbody != null)
        {
            if(collider.attachedRigidbody.mass / rb.mass > .6f)
                return;

            collider.tag = "Inner";
            collider.transform.parent = transform;
        
            MassAndSizeIncrease(collider.attachedRigidbody.mass);
            Destroy(collider.attachedRigidbody);
        }
    }

    void MassAndSizeIncrease(float massAdd)
    {
        rb.mass+= massAdd;
        //Sphere.localScale = Sphere.localScale + (massAdd *Vector3.one / 2);
    }
}
