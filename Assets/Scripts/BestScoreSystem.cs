using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BestScoreSystem : MonoBehaviour
{
    int bestScore;
    string bestPlayerName;
    string playerName;

    public Text bestScoreText;
    public InputField nameInput;

    public int currentSceneIndex;

    private void Start()
    {
        bestScoreText.text = $"Best Score: {PlayerPrefs.GetString("BestPlayer")} : {PlayerPrefs.GetInt("BestScore")}";
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetHighScore();
        }

        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentSceneIndex == 1)
        {
            MainManager mm = GameObject.Find("MainManager").GetComponent<MainManager>();
            Text g_bestScoreText = GameObject.Find("Canvas").transform.Find("GameBestScoreText").GetComponent<Text>();

            g_bestScoreText.text = $"Best Score: {PlayerPrefs.GetString("BestPlayer")} : {PlayerPrefs.GetInt("BestScore")}";

            if(mm.m_Points > bestScore)
            {
                bestScore = mm.m_Points;
                bestPlayerName = playerName;
                PlayerPrefs.SetInt("BestScore", bestScore);
                PlayerPrefs.SetString("BestPlayer", bestPlayerName);
            }
        }
    }

    public void NextScene()
    {
        playerName = nameInput.text;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteAll();
    }

}
