using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    private Player_Inp _Input;

    private bool _MenuActive = false;
    private GameObject _Canvas;
    private Scene _Scene;

    private Button _Resume;
    private Button _Restart;
    private Button _Quit;

    private void Awake()
    {
        _Input = new Player_Inp();
        _Canvas = GameObject.Find("PauseCanvas");
        _Resume = GameObject.Find("RESUME").GetComponent<Button>();
        _Restart = GameObject.Find("RESTART").GetComponent<Button>();
        _Quit = GameObject.Find("QUIT").GetComponent<Button>();
        print(_Restart);
    }

    private void OnEnable()
    {
        _Input.Enable();
        _Scene = SceneManager.GetActiveScene();
    }

    private void OnDisable()
    {
        _Input.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        Menu();
    }

    private void Menu()
    {
        if (_Input.Inp.Pause.triggered)
        {
            if (!_MenuActive)
            {
                _MenuActive = true;
                _Canvas.GetComponent<Canvas>().enabled = true;
                Time.timeScale = 0;
                print(_Restart);
                _Resume.onClick.AddListener(Resume);
                _Restart.onClick.AddListener(Restart);
                _Quit.onClick.AddListener(Quit);
            }
            else
            {
                Resume();
            }
        }
    }

    public void Resume()
    {
        _MenuActive = false;
        Time.timeScale = 1;
        _Canvas.GetComponent<Canvas>().enabled = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(_Scene.name);
        Time.timeScale = 1;
    }

    private void Quit()
    {
        Application.Quit();
    }
}
