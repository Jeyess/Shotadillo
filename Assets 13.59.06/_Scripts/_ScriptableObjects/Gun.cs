using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Gun : ScriptableObject
{
    public int GunID;

    public int Damage;
    public float Speed;
    public float Knockback;
    public int MagSize;
    public float ReloadTime;

    public float Timeout;
    public float ShrinkingRate;

    public int BulletCount;
    public float Spread;

    public float ExplosionRadius;
    public float ExplosionForce;
    public float ExplosiveFalloff;

    public Material Color;
}
