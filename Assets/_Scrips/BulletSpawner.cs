using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{ 
    private int ID = 0;

    public Gun guns;

    public GameObject Bullet;

    private float Timeout;
    private float ShrinkingRate;


    private int BulletCount;
    private int BulletDelta = 0;

    private float SpreadAngle;
    private float AngleDelta;

    // Start is called before the first frame update
    void Awake()
    {
        Timeout = guns.Timeout;
        ShrinkingRate = guns.ShrinkingRate;

        BulletCount = guns.BulletCount;

        if (BulletCount > 1)
        {
            SpreadAngle = guns.Spread / (BulletCount - 1);
            AngleDelta = guns.Spread / 2;
        }
        Multishot();


        Invoke("DestroyBullet", Timeout);
    }


    private void Multishot()
    {
        if (BulletDelta < BulletCount)
        {
            Instantiate(Bullet, transform.position, transform.rotation * Quaternion.Euler(0, 0, AngleDelta)).transform.SetParent(gameObject.transform);
            AngleDelta -= SpreadAngle;
            BulletDelta++;
            Multishot();
        }
    }


    private void Update()
    {
        BulletSizeChanger();
        LastBullet();
    }

    private void BulletSizeChanger()
    {
        gameObject.transform.localScale /= ShrinkingRate;
    }


    public void LastBullet()
    {
        //print(gameObject.transform.childCount);
        if (gameObject.transform.childCount <= 0)
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
