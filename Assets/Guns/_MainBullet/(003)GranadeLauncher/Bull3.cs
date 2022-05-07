using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bull3 : MonoBehaviour
{
    public float _ExplosionRadius;
    public float _ExplosionForce;
    public float _ExplosionFalloff;
    private _Bullet003 _Main;

    // Start is called before the first frame update
    void Awake()
    {
        _Main = gameObject.GetComponentInParent<_Bullet003>();
        print(_Main);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Ground" || other.transform.tag == "Enemy")
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _ExplosionRadius);
            foreach (var hitCollider in hitColliders)
            {
                if (hitCollider.transform.tag == "Player" || hitCollider.transform.tag == "Enemy")
                {
                    print(hitCollider);
                    Vector2 ExplosionDir = hitCollider.transform.position - transform.position;
                    float Distance = Vector2.Distance(hitCollider.transform.position, transform.position);
                    hitCollider.GetComponent<Rigidbody>().AddForce((ExplosionDir.normalized * _ExplosionForce) / (Distance * _ExplosionFalloff), ForceMode.Impulse);
                }
            }
            _Main.DestroyBullet();
        }
    }
}
