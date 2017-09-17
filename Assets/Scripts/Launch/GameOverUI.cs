using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour {

    public GameManager GameManager;
    public Image Panel;
    public string NextSceneName = "UpgradeScene";

    public Text ScoreText;
    public Text MoneyText;

	// Use this for initialization
	void Start () {
        GameManager.OnChange += GameManager_OnChange;
        Panel.gameObject.SetActive(false);
	}

    private void GameManager_OnChange(GameState state)
    {
        if (state == GameState.End)
        {
            Panel.gameObject.SetActive(true);

            GameManager.UpdateMoney();

            ScoreText.text = "Distance: " + GameManager.Score.ToString().PadLeft(6);
            MoneyText.text = "Money: $" + GameManager.Money.ToString();
            GameManager.Player.mouseLook.SetCursorLock(false);

        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void Continue()
    {
        SceneManager.LoadScene(NextSceneName);
    }
}
