using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    private GameObject _EnemySpawner;
    public GameObject _EnemyToSpawn;
    public float _SpawnRadius;
    public float _SpawnPointX;
    public float _SpawnPointY;
    public bool _Spawning;
    public int _Amount;
    public float _EnemyAmountMultiplier;

    public int _NextWaveTimer;
    private float _TimerDelta;
    private bool _ResetTimer = false;

    private int _EnemyDelta = 1;
    private bool _WaveCleared = false;


    private void Awake()
    {
        _EnemyDelta = _Amount;
        WaveTimeout();
    }

    // Update is called once per frame
    void Update()
    {
        Spawning();
        OnEnemyClear();
    }



    private void Spawning()
    {
        if (_Spawning && _EnemyDelta > 0)
        {
            _EnemySpawner = _EnemyToSpawn;
            Vector2 SpawnPos = new Vector2(Random.Range(_SpawnPointX + _SpawnRadius / 2, _SpawnPointX - _SpawnRadius / 2), Random.Range(_SpawnPointY + _SpawnRadius / 2, _SpawnPointY - _SpawnRadius / 2));
            Instantiate(_EnemySpawner, SpawnPos, Quaternion.identity).transform.SetParent(GameObject.Find("Enemies").transform);
            _EnemyDelta--;
        }
    }



    private void OnDrawGizmosSelected()
    {
        Color Blue = new Color(0, 0, 1, 0.35f);
        Gizmos.color = Blue;

        Gizmos.DrawCube(new Vector2(_SpawnPointX, _SpawnPointY), new Vector2(_SpawnRadius, _SpawnRadius));
    }

    private void WaveTimer()
    {
        if (_TimerDelta > 0 && !_ResetTimer)
        {
            print(_TimerDelta);
            _TimerDelta--;
            Invoke(nameof(WaveTimer), 1f);
        }
        else
        {
            _ResetTimer = true;
            WaveTimeout();
        }
    }

    private void OnEnemyClear()
    {
        if (GameObject.Find("Enemies").transform.childCount == 0 && !_WaveCleared)
        {
            _WaveCleared = true;
            Invoke(nameof(WaveTimeout), 0);
        }
    }

    private void WaveTimeout()
    {
        _Amount = Mathf.CeilToInt(_Amount * _EnemyAmountMultiplier);
        _EnemyDelta = _Amount;
        _WaveCleared = false;
        _TimerDelta = _NextWaveTimer;
        _ResetTimer = false;
        Invoke(nameof(WaveTimer), 1.5f);
    }
}
