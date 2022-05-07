using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpManeger : MonoBehaviour
{
    public float _StartingHP;
    private float _CurrentHP;

    private GameObject _Text;

    // Start is called before the first frame update
    void Awake()
    {
        _CurrentHP = _StartingHP;
        _Text = GameObject.Find("HPText");
        HPDisplay();
    }

    public void ApplyDamage(int Damage)
    {
        _CurrentHP -= Damage;
        _CurrentHP = Mathf.Clamp(_CurrentHP, 0, Mathf.Infinity);
        HPDisplay();
        if (_CurrentHP <= 0)
        {
            gameObject.GetComponent<GunBehavior>().enabled = false;
            gameObject.GetComponent<SphereCollider>().enabled = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            GameObject.Find("Gun").SetActive(false);
            GameObject.Find("Bill").SetActive(false);
            GameObject.Find("StartEnd").GetComponent<StartEnd>().SendMessage("EndScreen");
        }
    }

    private void HPDisplay()
    {
        string HPDesplayer = new string('|', Mathf.RoundToInt(_CurrentHP / 5));
        _Text.GetComponent<Text>().text = "HP " + HPDesplayer;
    }
}
