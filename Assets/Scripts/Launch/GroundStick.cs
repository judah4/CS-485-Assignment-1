using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundStick : MonoBehaviour
{
    //public enum NeighborIndex
    //{
    //    North,
    //    East,
    //    South,
    //    West
    //}

    [SerializeField]
    private GameManager _gameManager;

    //public GroundStick[] Neighbors = new GroundStick[4];

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	    //var playerPos = _gameManager.Player.transform.position;
	    //if (playerPos.z > transform.position.z && Neighbors[(int)NeighborIndex.North] == null)
	    //{
	    //    var gro = Instantiate(this);
	    //    gro.transform.position = transform.position + Vector3.forward * 1000;
	    //    Neighbors[(int) NeighborIndex.North] = gro;
     //       gro.Neighbors[(int) NeighborIndex.South] = this;
	    //    if (Neighbors[(int) NeighborIndex.East] != null
	    //        && Neighbors[(int) NeighborIndex.East].Neighbors[(int) NeighborIndex.North] != null)
	    //    {
	    //        Neighbors[(int) NeighborIndex.East].Neighbors[(int) NeighborIndex.North].Neighbors[(int) NeighborIndex.West] = gro;
	    //        gro.Neighbors[(int) NeighborIndex.West] = Neighbors[(int) NeighborIndex.East].Neighbors[(int) NeighborIndex.North];
	    //    }
     //       if (Neighbors[(int) NeighborIndex.West] != null
	    //        && Neighbors[(int) NeighborIndex.West].Neighbors[(int) NeighborIndex.North] != null)
	    //    {
	    //        Neighbors[(int) NeighborIndex.West].Neighbors[(int) NeighborIndex.North].Neighbors[(int) NeighborIndex.East] = gro;
     //           gro.Neighbors[(int) NeighborIndex.East] = Neighbors[(int) NeighborIndex.West].Neighbors[(int) NeighborIndex.North];

	    //    }
	    //}

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
