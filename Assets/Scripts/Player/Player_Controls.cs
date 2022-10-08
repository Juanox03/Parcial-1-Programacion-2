using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controls : MonoBehaviour
{
    private Player_Movement _movement;
    private float _inputMouseX, _inputMouseY, _inputVertical, _inputHorizontal;

    private void Awake()
    {
        _movement = GetComponent<Player_Movement>();
    }

    public void ArtificialUpdate()
    {
        _inputMouseX = Input.GetAxisRaw("Mouse X");
        _inputMouseY = Input.GetAxisRaw("Mouse Y");

        _inputVertical = Input.GetAxis("Vertical");
        _inputHorizontal = Input.GetAxis("Horizontal");

        if (_inputMouseX != 0 || _inputMouseY != 0)
        {
            _movement.Rotation(_inputMouseX, _inputMouseY);
        }

        if (_inputVertical != 0 || _inputHorizontal != 0)
        {
            _movement.Movement(_inputVertical, _inputHorizontal);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _movement.Jump();
        }
    }
}
