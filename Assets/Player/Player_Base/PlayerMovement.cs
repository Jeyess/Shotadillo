using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Player_Inp _Input;
    private Rigidbody _RB;
    private GameObject _Cam;
    private GameObject _GrapplerHook;
    private GameObject _GrappleLine;
    private GameObject _Gun;

    public bool _Grapling;
    private float _GrappleHitLength;
    private float _GrappleLength;

    public float _MovementSpeed;

    public float _JumpPower;
    public float _JumpTimeout;
    private bool _Grounded;
    private bool _GroundTimeout = true;

    private GameObject _Pointer;
    private Vector2 _AimLimitor;
    public float _AimEdgeLimitor;



    private void Awake()
    {
        _Input = new Player_Inp();

        _RB = transform.GetComponent<Rigidbody>();

        _Pointer = GameObject.Find("AimPointer");

        _Gun = GameObject.Find("Gun");

        _Cam = GameObject.Find("MainCam");      

        _GrapplerHook = Resources.Load("GraplingHook/Hook") as GameObject;
        _GrappleLine = Resources.Load("GraplingHook/HookLine") as GameObject;

        float Ratio = Screen.width / Screen.height;
        _AimLimitor = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0));
        _AimLimitor = new Vector2(_AimLimitor.x - _AimEdgeLimitor, (_AimLimitor.x / Ratio) - _AimEdgeLimitor);
    }

    private void OnEnable()
    {
        _Input.Enable();
    }

    private void OnDisable()
    {
        _Input.Disable();
    }





    private void FixedUpdate()
    {
        Move();
        Aiming();
    }



    //Sideways movement of the player
    private void Move()
    {
        Vector2 Moving = _Input.Inp.Move.ReadValue<Vector2>();
        _RB.AddForce(new Vector2(Moving.x * _MovementSpeed * Time.deltaTime, 0));
    }



    //Uses the cureser to posioton the aim pointer and rotating the gun towards it and it's position
    private void Aiming()
    {
        Vector2 Aim = _Cam.GetComponent<Camera>().ScreenToWorldPoint(_Input.Inp.Aim.ReadValue<Vector2>());
        _Pointer.transform.position = new Vector3(Aim.x, Aim.y, -1);


        //print(_AimLimitor);

        float CamX = Mathf.Clamp((_Pointer.transform.position.x + transform.position.x) / 2, transform.position.x - _AimLimitor.x, transform.position.x + _AimLimitor.x);
        float CamY = Mathf.Clamp((_Pointer.transform.position.y + transform.position.y) / 2, transform.position.y - _AimLimitor.y, transform.position.y + _AimLimitor.y);
        _Cam.gameObject.transform.position = new Vector3(CamX, CamY, -10);
    }





    private void Update()
    {
        Grappling();
        GroundCheck();
    }



    //Checks if jump is triggred and the player can jump
    private void GroundCheck()
    {
        Vector2 Jumping = _Input.Inp.Move.ReadValue<Vector2>();
        if (_Input.Inp.Move.triggered && _Grounded && _GroundTimeout && Jumping.y > 0)
        {
            _Grounded = false;
            _GroundTimeout = false;
            Invoke(nameof(JumpReset), _JumpTimeout);
            _RB.AddForce(new Vector2(0 ,_JumpPower), ForceMode.Impulse);
        }
    }

    private void JumpReset()
    {
        _GroundTimeout = true;
    }

    //Checks if player is touching the ground
    private void OnCollisionStay(Collision collision)
    {
        if (_GroundTimeout && !_Grounded && collision.gameObject.tag == "Ground")
        {
            _Grounded = true;
        }
    }



    //
    private void Grappling()
    {
        RaycastHit Hit;
        if (_Input.Inp.Grapple.triggered && !_Grapling)
        {
            Physics.Raycast(transform.position, _Gun.transform.TransformDirection(Vector3.up), out Hit, 1000f, LayerMask.GetMask("Grappble"));
            //print(Hit.transform);
            if(Hit.transform != null)
            {
                Instantiate(_GrapplerHook, Hit.point, transform.rotation);
                _GrappleHitLength = Vector2.Distance(GameObject.Find("Hook(Clone)").transform.position, transform.position);
                _GrappleHitLength += 0.01f; 
                Instantiate(_GrappleLine, new Vector3(GameObject.Find("Hook(Clone)").transform.position.x, GameObject.Find("Hook(Clone)").transform.position.y, 1), Quaternion.identity);
                _Grapling = true;
            }
        }
        else if (_Input.Inp.Grapple.triggered && _Grapling)
        {
            Destroy(GameObject.Find("Hook(Clone)"));
            Destroy(GameObject.Find("HookLine(Clone)"));
            _Grapling = false;
        }

        if (_Grapling)
        {
            GameObject.Find("HookLine(Clone)").transform.rotation = Quaternion.FromToRotation(Vector2.up, GameObject.Find("Hook(Clone)").transform.position - transform.position);
            _GrappleLength = Vector2.Distance(GameObject.Find("Hook(Clone)").transform.position, transform.position);
            _GrappleLength = Mathf.Clamp(_GrappleLength, 0, _GrappleHitLength);
            GameObject.Find("HookLine(Clone)").transform.localScale = new Vector3(1, _GrappleLength, 1);
            transform.rotation = Quaternion.FromToRotation(Vector2.up, GameObject.Find("Hook(Clone)").transform.position - transform.position);
            if (_GrappleLength >= _GrappleHitLength)
            {
                var locVel = transform.InverseTransformDirection(_RB.velocity);
                locVel.y = 0;
                _RB.velocity = transform.TransformDirection(locVel);
            }
            transform.position = new Vector3(GameObject.Find("HookLineEnd").transform.position.x, GameObject.Find("HookLineEnd").transform.position.y, 0);
        }
    }
}
