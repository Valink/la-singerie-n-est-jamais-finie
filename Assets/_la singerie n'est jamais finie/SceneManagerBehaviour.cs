using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagerBehaviour : MonoBehaviour
{
    [SerializeField] private Button playButton;

    void OnEnable()
    {
        playButton.onClick.AddListener(LaunchGame);
    }

    void OnDisable()
    {
        playButton.onClick.RemoveListener(LaunchGame);
    }

    private void LaunchGame()
    {
        SceneManager.LoadScene("Game");
    }
}
