using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Bullet003 : MonoBehaviour
{
    public float _BulletTimeout;
    public float _BulletShrinking;
    public float _BulletSpeed;

    private GameObject _Shot1;


    private void Awake()
    {
        _Shot1 = gameObject.transform.Find("Bullet 3").gameObject;

        _Shot1.GetComponent<Rigidbody>().AddForce(_Shot1.transform.up * _BulletSpeed, ForceMode.Impulse);

        Invoke("DestroyBullet", _BulletTimeout);
    }


    public void DestroyBullet()
    {
        Destroy(gameObject);
    }


    void Update()
    {
        transform.localScale = transform.localScale / _BulletShrinking;
    }
}
