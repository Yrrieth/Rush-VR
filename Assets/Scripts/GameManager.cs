using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverCanvas;
    bool isGameOver;

    float maxTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas.SetActive(false);
        Time.timeScale = 1;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (isGameOver == true)
        {
            maxTime -= Time.deltaTime;
            if (maxTime <= 0)
            {
                Time.timeScale = 1;
                isGameOver = false;
                SceneManager.LoadScene(0);
            }
            
        }
    }

    public void gameOver()
    {
        gameOverCanvas.SetActive(true);
        //Time.timeScale = 0;
        isGameOver = true;
        return;
    }
}
