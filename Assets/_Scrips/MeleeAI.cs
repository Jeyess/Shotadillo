using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAI : MonoBehaviour
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

    public float _ObstcleDetectionRange;
    private LayerMask _GroundMask;

    public GameObject _PosChecker;
    private Vector3 _CheckerFixedPos;
    private bool _InPos = false;
    private int _Cycle = 0;

    private bool _HitTimeout = false;
    public float _Damage;
    public float _TimeBetweenHits;

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
        if (_PlayerInRange && Hit.transform.tag == "Player")
        {
            _PlayerInSight = true;
            _PlayerLastPos = _Player.transform.position;
            RaycastHit Obstcle;
            Vector2 PlayerDirX = new Vector2(PlayerDir.x, 0).normalized;
            Physics.Raycast(transform.position + Vector3.down * transform.localScale.y / 2, PlayerDirX, out Obstcle, _ObstcleDetectionRange);
            print(transform.position + " EEE " + (transform.position - Vector3.down * transform.localScale.y / 2));
            if (Physics.CheckSphere(transform.position, 1, _GroundMask))
            {
                if (Obstcle.transform == null || Obstcle.transform.tag != "Ground")
                {
                    _RB.velocity = PlayerDirX * _TrackSpeed * Time.deltaTime + Vector2.up * _RB.velocity.y;
                    _InPos = false;
                    _Cycle = 0;
                    _PosChecker.transform.position = transform.position;
                }
                else
                {
                    if (_InPos)
                    {
                        _RB.velocity = Vector3.up * ((_PosChecker.transform.position - transform.position).normalized.y + 1) * _TrackSpeed / 2 * Time.deltaTime;
                        _PosChecker.transform.position = _CheckerFixedPos;
                    }
                    else
                    {
                        HeightCheck(PlayerDirX);
                        _CheckerFixedPos = _PosChecker.transform.position;
                    }
                }
            }
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
                if (Physics.CheckSphere(transform.position, 1, _GroundMask))
                {
                    Vector2 PlayerDir = (_PlayerLastPos - transform.position).normalized;
                    //print(PlayerDir);
                    RaycastHit Obstcle;
                    Vector2 PlayerDirX = new Vector2(PlayerDir.x, 0).normalized;
                    Physics.Raycast(transform.position + Vector3.down * transform.localScale.y / 2, PlayerDirX, out Obstcle, _ObstcleDetectionRange);
                    if (Obstcle.transform == null || Obstcle.transform.tag != "Ground")
                    {
                        _RB.velocity = PlayerDirX * _TrackSpeed * Time.deltaTime + Vector2.up * _RB.velocity.y;
                        _InPos = false;
                        _Cycle = 0;
                        _PosChecker.transform.position = transform.position;
                    }
                    else
                    {
                        if (_InPos)
                        {
                            _RB.velocity = Vector3.up * ((_PosChecker.transform.position - transform.position).normalized.y + 1) * _TrackSpeed / 2 * Time.deltaTime;
                            _PosChecker.transform.position = _CheckerFixedPos;
                        }
                        else
                        {
                            HeightCheck(PlayerDirX);
                            _CheckerFixedPos = _PosChecker.transform.position;
                        }
                    }
                }
                if (Vector3.Distance(new Vector2(_PlayerLastPos.x, transform.position.y), transform.position) < 0.2)
                {
                    _PlayerLastPos = Vector3.zero;
                }
            }
        }
        else if (!_MoveTimeout)
        {
            _MoveTimeout = true;
            _RndX = Random.Range(-5, 6);
            Invoke(nameof(MoveTimer), _MoveTimeLimit);
        }
    }



    private void Scouting()
    {
        if (_MoveTimeout)
        {
            Vector2 Scouting = new Vector2(_RndX, 0);
            _RB.velocity = Scouting * _TrackSpeed / 4 * Time.deltaTime + Vector2.up * _RB.velocity.y;
        }
    }

    private void HeightCheck(Vector2 DirX)
    {
        if (_Cycle == 0)
        {
            _PosChecker.transform.position = new Vector2(_PosChecker.transform.position.x + DirX.x, _PosChecker.transform.position.y);
        }
        else
        {
            _PosChecker.transform.position = new Vector2(_PosChecker.transform.position.x, _PosChecker.transform.position.y + 1);
            if (!Physics.CheckSphere(_PosChecker.transform.position, 1, _GroundMask))
            {
                _InPos = true;
                _PosChecker.transform.position += Vector3.up;
            }
        }
        _Cycle++;
    }

    private void MoveTimer()
    {
        _MoveTimeout = false;
    }


    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player" && !_HitTimeout)
        {
            collision.transform.SendMessage("ApplyDamage", _Damage);
            _HitTimeout = true;
            Invoke(nameof(HitTimer), _TimeBetweenHits);
        }
    }


    private void HitTimer()
    {
        _HitTimeout = false;
    }


    private void OnDrawGizmosSelected()
    {
        Color Yellow = new Color(1, 1, 0, 0.35f);
        Color Red = new Color(1, 0, 0, 0.35f);

        if (_PlayerInRange) Gizmos.color = Red;
        else Gizmos.color = Yellow;

        //Gizmos.DrawSphere(transform.position, _CheckRange);
        Gizmos.DrawSphere(_PosChecker.transform.position, 1);
    }
}
