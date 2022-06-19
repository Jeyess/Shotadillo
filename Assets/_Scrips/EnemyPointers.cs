using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointers : MonoBehaviour
{
    private GameObject _Player;

    private void Awake()
    {
        _Player = GameObject.Find("Player");    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = _Player.transform.position;
    }
}
