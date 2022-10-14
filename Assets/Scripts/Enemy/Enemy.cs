using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : Entity
{
    [Header("Values")]
    [SerializeField] private float _speed;
    [Header("Distances")]
    [SerializeField] private float _distanceToCheck;
    [SerializeField] private float _distanceToChase;
    [SerializeField] private float _distanceToAttack;
    [Header("AI")]
    [SerializeField] private Transform _target;
    [SerializeField] private List<Transform> _navMeshNodes = new List<Transform>();

    private Rigidbody _myRB;
    private Transform _actualWaypoint;

    private NavMeshAgent _myNMA;

    private void Start()
    {
        _myRB = GetComponent<Rigidbody>();
        _myNMA = GetComponent<NavMeshAgent>();

        _actualWaypoint = _navMeshNodes[Random.Range(0, _navMeshNodes.Count)];
        _myNMA.SetDestination(_actualWaypoint.position);
    }

    private void Update()
    {
        var distanceToTarget = Vector3.Distance(_target.position, transform.position);
        var distanceToWaypoint = Vector3.Distance(_actualWaypoint.position, transform.position);

        if (distanceToTarget <= _distanceToChase)
        {
            _myNMA.isStopped = true;
            LookAt(_target.position);
            if (distanceToTarget <= _distanceToAttack)
            {
                print($"I'm attacking my target.");
            }
            else Move();
        }
        else
        {
            if (_myNMA.isStopped) _myNMA.isStopped = false;
            if (distanceToWaypoint <= _distanceToCheck)
            {
                GetNewNode(_actualWaypoint);
                _myNMA.SetDestination(_actualWaypoint.position);
                print($"I'm changing my destination.");
            }
        }
    }

    private void Move()
    {
        var dir = _target.position - transform.position;
        dir.y = 0;

        transform.position += dir * _speed * Time.deltaTime;
    }

    private void GetNewNode(Transform actualNode)
    {
        var newWaypoint = _navMeshNodes[Random.Range(0, _navMeshNodes.Count)];
        if (newWaypoint == actualNode) GetNewNode(actualNode);
        else _actualWaypoint = newWaypoint;
    }

    private void LookAt(Vector3 target)
    {
        var lookPos = target - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime);
    }

    public override void Damage()
    {
        Debug.Log("ATTACK ENEMY");
    }
    public override void TakeDamage(float dmg)
    {
        life -= dmg;

        if (life <= 0)
            Destroy(gameObject);
    }
}

