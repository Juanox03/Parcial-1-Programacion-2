using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _mouseSensitivity;
    [SerializeField] private float _jumpForce;
    
    private Rigidbody _rb;
    private Ray _jumpRay;
    private Player_Camera _camera;
    private float _mouseX;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public void Movement(float yAxis, float xAxis)
    {
        Vector3 direction = (transform.forward * yAxis + transform.right * xAxis);

        if (direction.magnitude > 1)
        {
            direction.Normalize();
        }

        _rb.MovePosition(transform.position + direction * _movementSpeed * Time.fixedDeltaTime);
    }

    public void Rotation(float xAxis, float yAxis)
    {
        _mouseX += xAxis * _mouseSensitivity * Time.deltaTime;

        if (_mouseX >= 360 || _mouseX <= -360)
        {
            _mouseX -= 360 * Mathf.Sign(_mouseX);
        }

        yAxis *= _mouseSensitivity * Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, _mouseX, 0);

        _camera?.Rotate(_mouseX, yAxis);

    }

    public void Jump()
    {
        _jumpRay = new Ray(transform.position, Vector3.down);

        if(Physics.Raycast(_jumpRay, 1.3f))
        {
            _rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
}
