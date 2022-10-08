using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private bool _doorOpen;
    [SerializeField] private float _doorOpenAngle;
    [SerializeField] private float _doorCloseAngle;
    [SerializeField] private float _speed;

    public void ChangeDoorState()
    {
        _doorOpen = !_doorOpen;
    }

    private void Update()
    {
        if (_doorOpen)
        {
            Quaternion rotation = Quaternion.Euler(0, _doorOpenAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, _speed * Time.deltaTime);
        }
        else
        {
            Quaternion rotation2 = Quaternion.Euler(0, _doorCloseAngle, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation2, _speed * Time.deltaTime);
        }
    }
}
