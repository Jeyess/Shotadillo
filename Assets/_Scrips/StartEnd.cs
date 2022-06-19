using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartEnd : MonoBehaviour
{
    public Button _Restart;
    public Button _Quit;
    private GameObject _Canvas;
<<<<<<< Updated upstream
=======
    private GameObject _Player;
>>>>>>> Stashed changes
    private Scene _Scene;

    private float _Score;

    private void Awake()
    {
        _Canvas = GameObject.Find("EndCanvas");
        _Scene = SceneManager.GetActiveScene();
<<<<<<< Updated upstream
=======
        _Player = GameObject.Find("Player");
>>>>>>> Stashed changes
    }

    public void AddScore()
    {
        _Score += 100;
        GameObject.Find("ScoreText").GetComponent<Text>().text = "Score : " + _Score;
    }

    public void EndScreen()
    {
        _Player.GetComponent<Collider>().enabled = false;
        Time.timeScale = 0;
        Cursor.visible = true;
        _Canvas.GetComponent<Canvas>().enabled = true;
        GameObject.Find("Score").GetComponent<Text>().text = "Score : " + _Score;
        _Restart.onClick.AddListener(Restart);
        _Quit.onClick.AddListener(Quit);
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
