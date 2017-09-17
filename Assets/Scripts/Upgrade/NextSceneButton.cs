using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneButton : MonoBehaviour
{

    public string SceneName;

	// Use this for initialization
	void Start () {
		
	}
	

    public void Click()
    {
        SceneManager.LoadScene(SceneName);
    }
}
