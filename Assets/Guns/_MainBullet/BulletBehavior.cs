using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public Gun guns;

    public GameObject Spawner;

    private Rigidbody rb;

    private float Damage;

    private bool IsExplosion;
    private float ExplosionForce;
    private float ExplosionRadius;
    private float ExplosionFalloff;

    private void Awake()
    {
        guns = Spawner.GetComponent<BulletSpawner>().guns;

        rb = gameObject.GetComponent<Rigidbody>();

        rb.velocity = transform.TransformDirection(Vector2.up * guns.Speed);

        Damage = guns.Damage;

        IsExplosion = Spawner.GetComponent<BulletSpawner>().guns.ExplosionForce > 0;
        if (IsExplosion)
        {
            ExplosionForce = guns.ExplosionForce;
            ExplosionRadius = guns.ExplosionRadius;
            ExplosionFalloff = guns.ExplosiveFalloff;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "Enemy" || collision.transform.tag == "Ground")
        {
            rb.velocity = Vector3.zero;

            if (IsExplosion)
            {
                Collider[] hitColliders = Physics.OverlapSphere(transform.position, ExplosionRadius);
                foreach(var Hit in hitColliders)
                {
                    if (Hit.transform.tag == "Player" || Hit.transform.tag == "Enemy")
                    {
                        Vector2 Dir = Hit.transform.position - transform.position;
                        float Distance = Vector2.Distance(Hit.transform.position, transform.position);
                        Hit.GetComponent<Rigidbody>().AddForce(Dir * ExplosionForce / (Distance * ExplosionFalloff), ForceMode.Impulse);
                        if (Hit.transform.tag == "Enemy")
                        {
                            Hit.SendMessage("ApplyDamage", Mathf.RoundToInt(Damage / (Distance * ExplosionFalloff)));
                        }
                    }
                }
            }
            else if (collision.transform.tag == "Enemy")
            {
                collision.SendMessage("ApplyDamage", Damage);
            }

            Spawner.GetComponent<BulletSpawner>().LastBullet();
            Destroy(gameObject);
        }
    }
}
