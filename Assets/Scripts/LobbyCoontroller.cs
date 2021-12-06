using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LobbyCoontroller : MonoBehaviour
{
    public Button PlayButton;
    public Button StartButton;
    public Button GameRules;
    public Button BackButton;
    public GameObject Buttons;
    public GameObject pop_up;
    public GameObject gameRules;

    private void Start()
    {
        PlayButton.onClick.AddListener(clickPlayButton);
    }

    private void clickPlayButton()
    {
        pop_up.SetActive(true);
        StartButton.onClick.AddListener(clickStartButton);
        GameRules.onClick.AddListener(clickGrButton);
    }

    private void clickGrButton()
    {
        gameRules.SetActive(true);
        Buttons.SetActive(false);
        BackButton.onClick.AddListener(clickBackButton);

    }

    private void clickBackButton()
    {
        gameRules.SetActive(false);
        Buttons.SetActive(true);
    }

    private void clickStartButton()
    {
        SceneManager.LoadScene(1);
    }
}
