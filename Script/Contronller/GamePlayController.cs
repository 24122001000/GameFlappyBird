using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayController : MonoBehaviour
{
    public static GamePlayController instance;

    [SerializeField]
    private Button intructionBtn;
    [SerializeField]
    private Text scoreText,endScoreText,bestScoreText;
    [SerializeField]
    private GameObject gameOverPanel,pausePanel;

    private void Awake()
    {
        Time.timeScale = 0;
        MakeInstance();
    }

    private void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void IntructionButton()
    {
        Time.timeScale = 1;
        intructionBtn.gameObject.SetActive(false);
    }

    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
    }

    public void ShowPanel(int score)
    {
        gameOverPanel.SetActive(true);

        endScoreText.text = score.ToString();
        if (score > GameManager.instance.GetHighScore())
        {
            GameManager.instance.SetHighScore(score);
        }
        bestScoreText.text = GameManager.instance.GetHighScore().ToString();
    }

    public void MenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGameButton()
    {
        SceneManager.LoadScene(1);
    }

    public void PauseButton()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }
    public void ResumeButton()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }
}
