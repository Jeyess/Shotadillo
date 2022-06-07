using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GHook : MonoBehaviour
{
    private Rigidbody _RB;


    void Start()
    {
        _RB = gameObject.GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        
    }
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Ground")
        {
            _RB.isKinematic = true;
            //print(true);
            GameObject.Find("HookLineRenderer").GetComponent<LineCol>()._AnchorNum++;
        }
    }
}
