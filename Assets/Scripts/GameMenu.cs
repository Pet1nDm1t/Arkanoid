using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{
    [SerializeField]private GameObject _menu;
    private Controller _controller;

    private void Awake()
    {
        _controller = new Controller();
    }
    private void OnEnable()
    {
        _controller.ActionMap.Enable();
        _controller.ActionMap.Menu.performed += _ => OnMenu();
    }
    private void OnDisable()
    {
        _controller.ActionMap.Disable();
    }
    private void OnMenu()
    {
        _menu.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        _menu.SetActive(false);
        Time.timeScale = 1f;
    }
    public void ExitGame()
    {
        Debug.Log("Игра закрылась");
        Application.Quit();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }

}
