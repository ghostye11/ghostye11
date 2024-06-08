using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    private float score;
    private float highScore;

    // Start is called before the first frame update
    void Start()
    {
        LoadHighScore();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = "Score: " + ((int)score).ToString();
        }
        else
        {
            GameOver();
        }
    }

    void GameOver()
    {
        UpdateHighScore();

        // Any additional game over logic goes here
    }

    void UpdateHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
            Debug.Log("New High Score: " + highScore);
            SaveHighScore();
        }

        highScoreText.text = "High Score: " + ((int)highScore).ToString();
    }

    void LoadHighScore()
    {
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
        highScoreText.text = "High Score: " + ((int)highScore).ToString();
    }

    void SaveHighScore()
    {
        PlayerPrefs.SetFloat("HighScore", highScore);
    }

    public void Restart()
    {
        score = 0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
