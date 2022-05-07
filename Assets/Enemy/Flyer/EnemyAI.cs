using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private GameObject _Player;
    private Rigidbody _RB;

    private bool _PlayerInRange;
    private LayerMask _PlayerMask;
    private bool _PlayerInSight;
    public float _CheckRange;

    public float _TrackSpeed;

    private Vector3 _PlayerLastPos = Vector3.zero;
    private bool _MoveTimeout = false;
    public float _MoveTimeLimit;

    private float _RndX;
    private float _RndY;

    public float _ObstcleDetectionRange;
    private LayerMask _GroundMask;


    
    // Start is called before the first frame update
    void Awake()
    {
        _Player = GameObject.Find("Player");
        _RB = gameObject.GetComponent<Rigidbody>();
        _PlayerMask = LayerMask.GetMask("Player");
        _GroundMask = LayerMask.GetMask("Grappble");
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerCheck();
        FollowPlayer();
        Tracking();
        Scouting();
    }



    private void PlayerCheck()
    {
        _PlayerInRange = Physics.CheckSphere(transform.position, _CheckRange, _PlayerMask);
    }



    private void FollowPlayer()
    {
        RaycastHit Hit;
        Vector2 PlayerDir = (_Player.transform.position - transform.position).normalized;
        Physics.Raycast(transform.position, PlayerDir, out Hit, 100f);
        //print(Hit.transform.tag);
        if (_PlayerInRange && Hit.transform.tag == "Player")
        {
            _PlayerInSight = true;
            _RB.AddForce(PlayerDir * _TrackSpeed * Time.deltaTime, ForceMode.Force);
            _PlayerLastPos = _Player.transform.position;
            _MoveTimeout = false;
        }
        else _PlayerInSight = false;
    }



    private void Tracking()
    {
        if (_PlayerLastPos != Vector3.zero)
        {
            if (!_PlayerInSight)
            {
                Vector2 PlayerDir = (_PlayerLastPos - transform.position).normalized;
                //print(PlayerDir);
                _RB.AddForce(PlayerDir * _TrackSpeed * Time.deltaTime, ForceMode.Force);
                if (Vector3.Distance(_PlayerLastPos, transform.position) < 0.2)
                {
                    _PlayerLastPos = Vector3.zero;
                }
            }
        }
        else if(!_MoveTimeout)
        {
            _MoveTimeout = true;
            _RndX = Random.Range(-5, 6);
            _RndY = Random.Range(-5, 6);
            Invoke(nameof(MoveTimer), _MoveTimeLimit);
        }
    }



    private void Scouting()
    {
        if (_MoveTimeout)
        {
            Vector2 Scouting = new Vector2(_RndX, _RndY).normalized;
            _RB.AddForce(Scouting * _TrackSpeed * Time.deltaTime, ForceMode.Force);
        }
    }

    private void MoveTimer()
    {
        _MoveTimeout = false;
    }



    private void OnCollisionStay(Collision collision)
    {
        _RndX = Random.Range(-5, 6);
        _RndY = Random.Range(-5, 6);
        _RB.AddForce(new Vector2(_RndX, _RndY).normalized * _TrackSpeed * Time.deltaTime, ForceMode.Force);
    }


    private void OnDrawGizmosSelected()
    {
        Color Yellow = new Color(1, 1, 0, 0.35f);
        Color Red = new Color(1, 0, 0, 0.35f);

        if (_PlayerInRange) Gizmos.color = Red;
        else Gizmos.color = Yellow;

        Gizmos.DrawSphere(transform.position, _CheckRange);
    }
}
