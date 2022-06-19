using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShowPosition : MonoBehaviour
{
    private GameObject _Player;
    private Camera _Cam;
    private Vector2 _PosReletiveToPlayer;
    private bool _OutOfCameraRange = false;

    public GameObject _PointerSpawn;
    private GameObject _Pointer;
    public float _PointerDistance;

    private void Awake()
    {
        _Player = GameObject.Find("Player");

        _Cam = GameObject.Find("MainCam").GetComponent<Camera>();
    }

    // Update is called once per frame
    private void Update()
    {
        InCamRange();
        Pointer();
    }

    private void InCamRange()
    {
        _PosReletiveToPlayer = _Cam.WorldToViewportPoint(transform.position);
        if (_PosReletiveToPlayer.x > 1 || _PosReletiveToPlayer.x < 0 || _PosReletiveToPlayer.y > 1 || _PosReletiveToPlayer.y < 0)
        {
            if (!_OutOfCameraRange)
            {
                _OutOfCameraRange = true;
            }
        }
        else
        {
            _OutOfCameraRange = false;
        }
    }

    private void Pointer()
    {
        if (_OutOfCameraRange)
        {
            Vector3 _PointerPos = _Player.transform.position + (transform.position - _Player.transform.position).normalized * _PointerDistance + Vector3.back * 6;
            if (_Pointer == null)
            {
                _Pointer = Instantiate(_PointerSpawn, _PointerPos , Quaternion.identity, GameObject.Find("EnemyPointers").transform);
            }
            else
            {
                _Pointer.transform.position = _PointerPos;
            }
        }
        else
        {
            if (_Pointer != null)
            {
                Destroy(_Pointer);
            }
        }
    }
}
