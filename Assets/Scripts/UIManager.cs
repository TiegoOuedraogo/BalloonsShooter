using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    int score = 0;
    [SerializeField] TextMeshProUGUI scoreText;

    public GameObject pause;
    public GameObject resume;

    // Start is called before the first frame update
    public void AddScore(int _score)
    {
        score += _score;
        scoreText.text = score.ToString();
        PlayerPrefs.SetInt("score", score);
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("score"))
        {
            score = PlayerPrefs.GetInt("score");
        } else
        {
            PlayerPrefs.SetInt("score", 0);
        }
        scoreText.text = score.ToString();
        Time.timeScale = 1;
    }

    public void LoadScene()
    {
        Invoke("LoadSceneWithDelay", 3f);
    }

    void LoadSceneWithDelay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadSceneCurrent()
    {
        Invoke("LoadSceneCurrentWithDelay", 3f);
    }

    void LoadSceneCurrentWithDelay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void OnHome()
    {
        SceneManager.LoadScene(0);
    }
    public void Resume()
    {
        Time.timeScale = 1;
        resume.SetActive(false);
        pause.SetActive(true);
    }
    public void Pause()
    {
        Time.timeScale = 0;
        resume.SetActive(true);
        pause.SetActive(false);
    }
}

