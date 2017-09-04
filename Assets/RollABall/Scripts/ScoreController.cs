using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{

    public PlayerController PlayerController;

    public Text countText;
    public Image winPanel;

    private int count;

	// Use this for initialization
	void Start () {

        count = 0;
        SetCountText ();
        //winText.text = "";
        winPanel.gameObject.SetActive(false);

        PlayerController.OnScore += PlayerController_OnScore;
	}

    private void PlayerController_OnScore(int addScore)
    {
        count += addScore;
        SetCountText();
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            BackToMenu();
        }
	}

    void SetCountText ()
    {
        countText.text = "Score: " + count.ToString().PadLeft(3, '0');
        if (count >= 110)
        {
            //winText.text = "You Win!";
            winPanel.gameObject.SetActive(true);

        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
