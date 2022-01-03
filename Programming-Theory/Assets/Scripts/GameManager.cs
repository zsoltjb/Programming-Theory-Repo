using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using System.IO;
using UnityEditor;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Button backToLobbyButton;
    public Button exitGameButton;
    public Button resumeButton;

    public GameObject pauseMenu;
    //ENCAPSULATION
    public bool IsGamePaused { get; set; }
    private GameObject sceneEventSystem;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);



        //Initialize pause menu button's event listeners
        backToLobbyButton.onClick.AddListener(BackToLobby);
        exitGameButton.onClick.AddListener(ExitApplication);
        resumeButton.onClick.AddListener(PauseGame);

        // Load data
    }

    public void BackToLobby()
    {
        SceneManager.LoadScene(0);
        Debug.Log("back to lobby");
    }

    public void ExitApplication()
    {
        Debug.Log("exit game");
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    public void PauseGame()
    {
        sceneEventSystem = GameObject.Find("EventSystem");

        if (!IsGamePaused)
        {
            Time.timeScale = 0;
            pauseMenu.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            IsGamePaused = true;
            if (sceneEventSystem != null)
            {
                sceneEventSystem.gameObject.SetActive(false);
            }
            
        } else
        {
            Time.timeScale = 1;
            pauseMenu.gameObject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            IsGamePaused = false;
            if (sceneEventSystem != null)
            {
                sceneEventSystem.gameObject.SetActive(true);
            }
        }

    }
}

