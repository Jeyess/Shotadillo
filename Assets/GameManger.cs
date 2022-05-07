using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManger : MonoBehaviour
{
    public GameObject _EnemySpawner;
    public float _SpawnRadius;
    public float _SpawnPointX;
    public float _SpawnPointY;
    public bool _Spawning;
    public int _Amount;



    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        Spawning();
    }



    private void Spawning()
    {
        if (_Spawning && _Amount > 0)
        {
            Vector2 SpawnPos = new Vector2(Random.Range(_SpawnPointX + _SpawnRadius / 2, _SpawnPointX - _SpawnRadius / 2), Random.Range(_SpawnPointY + _SpawnRadius / 2, _SpawnPointY - _SpawnRadius / 2));
            Instantiate(_EnemySpawner, SpawnPos, Quaternion.identity);
            _Amount--;
        }
    }



    private void OnDrawGizmosSelected()
    {
        Color Blue = new Color(0, 0, 1, 0.35f);
        Gizmos.color = Blue;

        Gizmos.DrawCube(new Vector2(_SpawnPointX, _SpawnPointY), new Vector2(_SpawnRadius, _SpawnRadius));
    }
}
