using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button StartGameButton;
    public Button ExitGameButton;

    private void Awake()
    {
        StartGameButton?.onClick.AddListener(OnStartGamePressed);
        ExitGameButton?.onClick.AddListener(OnExitGamePressed);
    }

    private void OnExitGamePressed()
    {
        Application.Quit();
    }

    private void OnStartGamePressed()
    {
        SceneManager.LoadScene("Game");
    }
}
