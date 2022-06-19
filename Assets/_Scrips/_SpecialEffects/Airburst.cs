using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airburst : MonoBehaviour
{
    private BulletBehavior _CurrentBullet;
    private GunBehavior _GunBehavior;
    private GameObject _Player;
    private Player_Inp _Input;

    #region SETUP
    private void Awake()
    {
        _Input = new Player_Inp();
        _Player = GameObject.Find("Player");
        _GunBehavior = _Player.GetComponent<GunBehavior>();
    }

    private void OnEnable()
    {
        _Input.Enable();
    }

    private void OnDisable()
    {
        _Input.Disable();
    }
    #endregion


    // Update is called once per frame
    private void Update()
    {
        Airburster();
    }

    private void Airburster()
    {
        if (GameObject.Find("Bullet(Clone)") != null)
        {
            _CurrentBullet = GameObject.Find("Bullet(Clone)").GetComponent<BulletBehavior>();
            if (_GunBehavior._CanShoot == false)
            {
                Active();
            }
            _GunBehavior._CanShoot = false;
        }
        else
        {
            _GunBehavior._CanShoot = true;
        }
    }

    private void Active()
    {
        if (_Input.Inp.Shoot.triggered)
        {
            _CurrentBullet.Explosion();
        }
    }
}
