using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{

    public Dictionary<Vector3, GroundStick> Grounds = new Dictionary<Vector3, GroundStick>();
    public GroundStick CenterGround;
    public GameManager GameManager;

	// Use this for initialization
	void Start () {
		Grounds.Add(Vector3.zero, CenterGround);
	}
	
	// Update is called once per frame
	void Update () {
	    var playerPos = GameManager.Player.transform.position;
	    var xPos = (int)(Mathf.RoundToInt(playerPos.x / 1000)) * 1000;
        var zPos = (int)(Mathf.RoundToInt(playerPos.z / 1000)) * 1000;

	    var loadPos = new Vector3(xPos, 0, zPos);
        Debug.Log("World loader: " +loadPos);
	    if (!Grounds.ContainsKey(new Vector3(xPos, 0, zPos)))
	    {
	        LoadGround(loadPos);
	    }
	    var posForward = loadPos + Vector3.forward * 1000;
        if (!Grounds.ContainsKey(posForward))
	    {
	        LoadGround(posForward);
	    }
        var posRight = loadPos + Vector3.right * 1000;
        if (!Grounds.ContainsKey(posRight))
	    {
	        LoadGround(posRight);
	    }
        var posLeft = loadPos + Vector3.left * 1000;
        if (!Grounds.ContainsKey(posLeft))
	    {
	        LoadGround(posLeft);
	    }

        var posRightFor = loadPos + Vector3.right * 1000 + Vector3.forward * 1000;
        if (!Grounds.ContainsKey(posRightFor))
	    {
	        LoadGround(posRightFor);
	    }
        var posLeftFor = loadPos + Vector3.left * 1000 + Vector3.forward * 1000;
        if (!Grounds.ContainsKey(posLeftFor))
	    {
	        LoadGround(posLeftFor);
	    }
	}

    private void LoadGround(Vector3 loadPos)
    {
        var newGround = Instantiate(Grounds[Vector3.zero]);
        newGround.transform.position = loadPos;
        Grounds.Add(loadPos, newGround);
    }
}
