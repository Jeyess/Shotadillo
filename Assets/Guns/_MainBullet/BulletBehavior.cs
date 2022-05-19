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

    private GameObject mySphere;

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
                ExplosionDisplay();
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


            Invoke(nameof(KillGameobjects), 0.1f);
        }
    }

    private void ExplosionDisplay()
    {
        mySphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        mySphere.transform.localScale = Vector3.one * ExplosionRadius * 2;
        mySphere.transform.position = transform.position + Vector3.back * 3;
        mySphere.GetComponent<SphereCollider>().enabled = false;
        Material mat = new Material(Shader.Find("Standard"));
        mat.SetColor("_Color", new Color(1, 0.5f, 0, 0.5f));

        mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        mat.EnableKeyword("_ALPHABLEND_ON");
        mat.renderQueue = 3000;

        mySphere.GetComponent<MeshRenderer>().material = mat;
    }

    private void KillGameobjects()
    {
        Spawner.GetComponent<BulletSpawner>().LastBullet();
        Destroy(mySphere);
        Destroy(gameObject);
    }
}
