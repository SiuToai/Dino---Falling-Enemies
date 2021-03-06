using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static MenuManager instance;

    public bool gameOver = false;

    [SerializeField]
    private Text scoreText, coinText, goScoreText, goCoinText;
    [SerializeField]
    private GameObject gameMenu, menu, gameOverMenu;

    private int currentCoin, currentScore;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "" + 0;
        coinText.text = "" + 0;
    }

    // Update is called once per frame
    public void IncreaseCoin()
    {
        currentCoin++;
        coinText.text = "" + currentCoin;
    }

    public void IncreaseScore()
    {
        currentScore++;
        scoreText.text = "" + currentScore;
    }

    public void PlayBtn()
    {
        SoundManager.instance.PlayClick();
        menu.SetActive(false);
        gameMenu.SetActive(true);
        Player.instance.StartMoving = true;
    }

    public void GameOver()
    {
        SoundManager.instance.PlayDeath();
        gameOver = true;
        gameMenu.SetActive(false);
        gameOverMenu.SetActive(true);
        goScoreText.text = "" + currentScore;
        goCoinText.text = "" + currentCoin;
    }

    public void HomeBtn()
    {
        SoundManager.instance.PlayClick();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
