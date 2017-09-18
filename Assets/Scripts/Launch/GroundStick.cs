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
    public GameManager GameManager;

    public List<GameObject> Prefabs = new List<GameObject>();
    public float Size = 1000;
    public float Distribution = 20;

    //public GroundStick[] Neighbors = new GroundStick[4];

	// Use this for initialization

	void Start () {
        for (int cntY = 0; cntY < Distribution; cntY++)
	    {
            for (int cntX = 0; cntX < Distribution; cntX++)
            {
                var spread = Size / Distribution;
                var groundObj = Instantiate(Prefabs[Random.Range(0, Prefabs.Count)]);
                groundObj.transform.position = transform.position + new Vector3((Size/2) - cntX * spread + Random.Range(-25,25), 0, (Size/2) -  cntY * spread + Random.Range(-25,25));
                groundObj.transform.rotation = Quaternion.Euler(0, Random.Range(0,360), 0);

            }
	    }
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
            GameManager.Player.SoundManager.PlayClip(1);
            GameManager.ChangeState(GameState.End);
        }
        
    }
}
