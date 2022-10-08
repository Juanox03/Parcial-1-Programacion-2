using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Camera : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float _yMinRotation;
    [SerializeField] private float _yMaxRotation;

    private float _mouseY;

    private Transform _playerHead;

    private void LateUpdate()
    {
        Movement();
    }

    public void SetPlayersHead(Transform headTransform)
    {
        _playerHead = headTransform;
    }

    private void Movement()
    {
        transform.position = _playerHead.position;
    }

    public void Rotate(float xAxis, float yAxis)
    {
        _mouseY += yAxis;
        _mouseY = Mathf.Clamp(_mouseY, _yMinRotation, _yMaxRotation);

        transform.rotation = Quaternion.Euler(-_mouseY, xAxis, 0f);
    }

}
