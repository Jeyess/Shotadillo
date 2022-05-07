using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartEnd : MonoBehaviour
{
    public Button _Restart;
    private GameObject _Canvas;

    private float _Score;

    private void Awake()
    {
        _Canvas = GameObject.Find("EndCanvas");
    }

    public void AddScore()
    {
        _Score += 100;
        GameObject.Find("ScoreText").GetComponent<Text>().text = "Score : " + _Score;
    }

    public void EndScreen()
    {
        _Canvas.GetComponent<Canvas>().enabled = true;
        GameObject.Find("Score").GetComponent<Text>().text = "Score : " + _Score;
        _Restart.onClick.AddListener(Restart);
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }


}
