using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsPanel : MonoBehaviour
{
    public RectTransform RectTransform;
    public float speed = 100;
	// Use this for initialization
	void Start ()
	{
	    StartCoroutine(MoveAway());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator MoveAway()
    {
        yield return new WaitForSeconds(2);

        while (true)
        {
            var pos = RectTransform.anchoredPosition;
            pos.x += speed * Time.deltaTime;
            RectTransform.anchoredPosition = pos;
            yield return 0;

            if (pos.x > 600)
                break;

        }

    }
}
