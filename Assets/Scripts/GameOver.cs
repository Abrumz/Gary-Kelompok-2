using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverPanel;

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0)
        {
            gameOverPanel.SetActive(true);
            FindObjectOfType<SoundEffects>().DeathSound();
            FindObjectOfType<SoundEffects>();
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
