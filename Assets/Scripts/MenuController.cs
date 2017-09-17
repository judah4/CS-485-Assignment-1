using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    public void Quit()
    {
        Application.Quit();
    }

    public void LoadScene(string sceneName)
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(sceneName);
    }

}
