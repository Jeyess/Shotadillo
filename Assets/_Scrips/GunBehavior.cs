using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunBehavior : MonoBehaviour
{
    private Player_Inp _Input;
    private GameObject _Gun;
    public Gun _gun1;
    public Gun _gun2;
    public GameObject _BulletSpawner;
    private Rigidbody _PlayerRB;
    private GameObject _Pointer;

    private int _AmmoLeft;
    private bool _Reloading;
    private int _MagSize;
    private float _ReloadTime;
    private float _ShotKnockback;
    
    Vector3 PointerPos;


    #region SETUP
    private void Awake()
    {
        _Input = new Player_Inp();

        _Gun = GameObject.Find("Gun");

        _PlayerRB = transform.GetComponent<Rigidbody>();

        _Pointer = GameObject.Find("AimPointer");

        _BulletSpawner.GetComponent<BulletSpawner>().guns = _gun1;  

        _MagSize = _BulletSpawner.GetComponent<BulletSpawner>().guns.MagSize;
        _AmmoLeft = _MagSize;

        _ReloadTime = _BulletSpawner.GetComponent<BulletSpawner>().guns.ReloadTime;

        _ShotKnockback = _BulletSpawner.GetComponent<BulletSpawner>().guns.Knockback;
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
    void Update()
    {
        PointerPos = new Vector3(_Pointer.transform.position.x, _Pointer.transform.position.y, 0);
        GunPositioning();
        Fire();
        Reload();
        SwitchWeapon();

    }


    private void GunPositioning()
    {
        _Gun.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        _Gun.transform.rotation = Quaternion.FromToRotation(Vector3.down, transform.position - PointerPos);
    }


    #region GunBaseMechanics
    //Summons the bullets prefab when triggred and ammo is more then 0
    private void Fire()
    {
        if (_Input.Inp.Shoot.triggered && _AmmoLeft > 0)
        {
            Vector3 Aim = Quaternion.Euler(0, 0, 15) * (PointerPos - transform.position).normalized;
            Instantiate(_BulletSpawner, transform.position, _Gun.transform.rotation);
            _PlayerRB.AddForce(_ShotKnockback * (transform.position - PointerPos).normalized, ForceMode.Impulse);
            _AmmoLeft--;
        }
    }

    //Reloading will happen when reload is triggered ammo reaches 0 and only if it's not already reloading
    private void Reload()
    {
        if (_Input.Inp.Reload.triggered && !_Reloading || _AmmoLeft == 0 && !_Reloading)
        {
            print("Reloading");
            _AmmoLeft = 0;
            _Reloading = true;
            Invoke("ReloadTimer", _ReloadTime);
        }
    }

    //Reloading timeout
    private void ReloadTimer()
    {
        _Reloading = false;
        _AmmoLeft = _MagSize;
    }
    #endregion


    //Weapon switching
    private void SwitchWeapon()
    {
        if (_Input.Inp.SwitchWeapon.triggered)
        {
            if (_gun1.GunID == _BulletSpawner.GetComponent<BulletSpawner>().guns.GunID)
            {
                _BulletSpawner.GetComponent<BulletSpawner>().guns = _gun2;
            }
            else
            {
                _BulletSpawner.GetComponent<BulletSpawner>().guns = _gun1;
            }

            _MagSize = _BulletSpawner.GetComponent<BulletSpawner>().guns.MagSize;
            _AmmoLeft = _MagSize;
            
            _ReloadTime = _BulletSpawner.GetComponent<BulletSpawner>().guns.ReloadTime;
            
            _ShotKnockback = _BulletSpawner.GetComponent<BulletSpawner>().guns.Knockback;
        }
    }
}
