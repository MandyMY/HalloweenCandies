using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Text startText;
    public Text overText;
    public bool isStart, isOver;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    private void Start()
    {
        startText.gameObject.SetActive(true);
        overText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!isStart && Input.GetMouseButtonDown(0))
        {
            StartGame();
        }

        if (isOver && Input.GetMouseButtonDown(0))
        {
            RestartGame();
        }
    }

    public void StartGame()
    {
        isStart = true;
        startText.gameObject.SetActive(false);
        Sounds.instance.BgM(true);
    }

    public void GameOver()
    {
        isOver = true;
        overText.gameObject.SetActive(true);
        Sounds.instance.DieM();
        Sounds.instance.BgM(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Game");
    }
}
