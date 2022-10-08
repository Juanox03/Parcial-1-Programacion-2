using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]private Transform _headPosition;
    
    private Player_Controls _controls;
    private Player_Camera _camera;
    
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _controls = GetComponent<Player_Controls>();
    }

    private void Start()
    {
        _camera = Camera.main.GetComponent<Player_Camera>();
        _camera?.SetPlayersHead(_headPosition);
    }

    private void Update()
    {
        _controls.ArtificialUpdate();
    }
}
