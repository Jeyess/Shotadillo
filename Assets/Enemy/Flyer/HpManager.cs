using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpManager : MonoBehaviour
{
    public float _StartingHP;
    private float _CurrentHP;
    private bool _Destroyed = false;

    // Start is called before the first frame update
    void Awake()
    {
        _CurrentHP = _StartingHP;
        Color DamagedShower = new Color((_StartingHP - _CurrentHP) / _StartingHP, _CurrentHP / _StartingHP, 0, 1);
        gameObject.GetComponent<Renderer>().material.color = DamagedShower;
    }

    public void ApplyDamage(int damage)
    {
        _CurrentHP -= damage;
        Color DamagedShower = new Color((_StartingHP - _CurrentHP) / _StartingHP, _CurrentHP / _StartingHP, 0, 1);
        gameObject.GetComponent<Renderer>().material.color = DamagedShower;
        if (_CurrentHP <= 0 && !_Destroyed)
        {
            _Destroyed = true;
            GameObject.Find("StartEnd").SendMessage("AddScore", 100);
            Destroy(gameObject);
        }
    }
}
