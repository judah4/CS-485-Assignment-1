using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneManager : MonoBehaviour
{

    public GameManager GameManager;
    public PlaneMover PlanePrefab;

	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(PlaneSpawn());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator PlaneSpawn()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(Random.Range(3, 10));
        }
    }

    void Spawn()
    {
        var plane = Instantiate(PlanePrefab);
        var playerPosAdj = GameManager.Player.transform.position;
        playerPosAdj.y = 0;
        var pos = Vector3.up * (100 + Random.Range(-20, 250)) + playerPosAdj + Vector3.forward * Random.Range(200, 1200);

        var randomDir = Random.Range(0, 3);
        if (randomDir == 0)
        {
            pos.x += -100 + -Random.Range(500, 900);
            plane.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if(randomDir == 1)
        {
            pos.x += 100 + Random.Range(500, 900);
            plane.transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if(randomDir == 2)
        {
            pos.x += -100 + -Random.Range(500, 900);
            plane.transform.rotation = Quaternion.Euler(0, 110, 0);
        }
        
        plane.transform.position = pos;


    }
}
