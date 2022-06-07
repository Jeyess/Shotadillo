using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private GameObject _Player;
    private GameObject _Pointer;
    private float _MeshScale;
    private bool _PlayerDirRight;

    // Start is called before the first frame update
    void Awake()
    {
        _Player = GameObject.Find("Player");
        _Pointer = GameObject.Find("AimPointer");
        _MeshScale = gameObject.transform.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(_Player.transform.position.x, _Player.transform.position.y - 0.5f);
        DirCheck();
        DirUpdate();
    }

    private void DirCheck()
    {
        if (_Pointer.transform.position.x > _Player.transform.position.x)
        {
            _PlayerDirRight = true;
        }
        else _PlayerDirRight = false;
    }

    private void DirUpdate()
    {
        if (_PlayerDirRight)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, _MeshScale);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, -_MeshScale);
        }
    }
}
