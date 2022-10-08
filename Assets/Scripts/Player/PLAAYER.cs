using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLAAYER : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpRange;
    [SerializeField] private float _openDoorRange;
    [Header("Components")]
    [SerializeField] private Transform _headPosition;

    private Rigidbody _myRB;
    private Ray _jumpRay;
    private RaycastHit _doorRay;
    private Player_Camera _myCam;
    private float _mouseX, _inputMouseX, _inputMouseY, _inputVertical, _inputHorizontal;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        _myRB = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _myCam = Camera.main.GetComponent<Player_Camera>();
        _myCam?.SetPlayersHead(_headPosition);
    }

    private void Update()
    {
        _inputMouseX = Input.GetAxisRaw("Mouse X");
        _inputMouseY = Input.GetAxisRaw("Mouse Y");

        _inputVertical = Input.GetAxis("Vertical");
        _inputHorizontal = Input.GetAxis("Horizontal");

        if (_inputMouseX != 0 || _inputMouseY != 0)
        {
            Rotation(_inputMouseX, _inputMouseY);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _doorRay, _openDoorRange))
        {
            if(_doorRay.collider.tag == "Door")
            {
                Debug.Log("H");
                if (Input.GetKeyDown(KeyCode.E))
                {
                    _doorRay.collider.transform.GetComponent<Door>().ChangeDoorState();
                }
            }
        }
    }

    private void FixedUpdate()
    {
        if (_inputVertical != 0 || _inputHorizontal != 0)
        {
            Movement(_inputVertical, _inputHorizontal);
        }
    }

    private void Movement(float yAxis, float xAxis)
    {
        Vector3 direction = (transform.forward * yAxis + transform.right * xAxis);

        if (direction.magnitude > 1)
        {
            direction.Normalize();
        }

        _myRB.MovePosition(transform.position + direction * _movementSpeed * Time.fixedDeltaTime);
    }

    private void Rotation(float xAxis, float yAxis)
    {
        _mouseX += xAxis * _mouseSensitivity * Time.deltaTime;

        if (_mouseX >= 360 || _mouseX <= -360)
        {
            _mouseX -= 360 * Mathf.Sign(_mouseX);
        }

        yAxis *= _mouseSensitivity * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, _mouseX, 0);

        _myCam?.Rotate(_mouseX, yAxis);

    }

    private void Jump()
    {
        _jumpRay = new Ray(transform.position, -Vector3.up);

        if(Physics.Raycast(_jumpRay, _jumpRange))
        {
            _myRB.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
