using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineCol : MonoBehaviour
{
    private GameObject _Anchor;
    private string _AnchorName; 
    public int _AnchorNum = 0;

    private PlayerMovement _Grp;
    private GameObject _Player;


    void Start()
    {
        _Anchor = Resources.Load("ZAnchor") as GameObject;
        _Grp = GameObject.Find("Player").GetComponent<PlayerMovement>();
        _Player = GameObject.Find("Player");
        _AnchorName = "ZAnchor";
    }


    private void OnCollisionEnter(Collision collision)
    {
        //print(collision);
        if (collision.transform.tag == "Ground")
        {
            Vector3 Closest = collision.contacts[0].point;
            int ColNum = 0;
            foreach (ContactPoint contacts in collision)
            {
                if (Vector3.Distance(_Player.transform.position, collision.contacts[ColNum].point) < Vector3.Distance(_Player.transform.position, Closest))
                {
                    Closest = collision.contacts[ColNum].point;
                }
                ColNum++;
            }
            Closest.z = 0;
            //Instantiate(_Anchor, GameObject.Find("Hook(Clone)").transform.position, Quaternion.identity).name = _AnchorName + _AnchorNum;
            //GameObject.Find("Hook(Clone)").transform.position = Closest;
            //GameObject.Find("HookLine(Clone)").transform.position = Closest;
        }
    }


    void Update()
    {
        //Anchors.ForEach(Num => print(Num));
        //print(Anchors.Count);
        GrappleCheck();
    }

    private void GrappleCheck()
    {
         
    }
}
