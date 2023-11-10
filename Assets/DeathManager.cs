using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{
    public TMP_Text currentScoreText, highScoreText;

    private void OnEnable()
    {
        currentScoreText.text = "Score: " + GameManager.Instance.score;
        highScoreText.text = "HighScore: " + PlayerPrefs.GetInt("HighScore");
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
