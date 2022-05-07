using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    private GameObject _EnemySpawner;
    public GameObject _EnemySpawnerType1;
    public GameObject _EnemySpawnerType2;
    public float _SpawnRadius;
    public float _SpawnPointX;
    public float _SpawnPointY;
    public bool _Spawning;
    public int _Amount;

    private int _EnemyDelta = 1;
    private bool _WaveCleared = false;


    private void Awake()
    {
        _Amount = _EnemyDelta;
    }

    // Update is called once per frame
    void Update()
    {
        Spawning();
        OnEnemyClear();
    }



    private void Spawning()
    {
        if (_Spawning && _Amount > 0)
        {
            int rnd = Random.Range(1, 4);
            if (rnd == 1)
                _EnemySpawner = _EnemySpawnerType1;
            else
                _EnemySpawner = _EnemySpawnerType2;
            Vector2 SpawnPos = new Vector2(Random.Range(_SpawnPointX + _SpawnRadius / 2, _SpawnPointX - _SpawnRadius / 2), Random.Range(_SpawnPointY + _SpawnRadius / 2, _SpawnPointY - _SpawnRadius / 2));
            Instantiate(_EnemySpawner, SpawnPos, Quaternion.identity).transform.SetParent(GameObject.Find("Enemies").transform);
            _Amount--;
        }
    }



    private void OnDrawGizmosSelected()
    {
        Color Blue = new Color(0, 0, 1, 0.35f);
        Gizmos.color = Blue;

        Gizmos.DrawCube(new Vector2(_SpawnPointX, _SpawnPointY), new Vector2(_SpawnRadius, _SpawnRadius));
    }



    private void OnEnemyClear()
    {
        if (GameObject.Find("Enemies").transform.childCount == 0 && !_WaveCleared)
        {
            _WaveCleared = true;
            Invoke(nameof(WaveTimeout), 3);
        }
    }

    private void WaveTimeout()
    {
        _EnemyDelta *= 2;
        _Amount = _EnemyDelta;
        _WaveCleared = false;
    }
}
