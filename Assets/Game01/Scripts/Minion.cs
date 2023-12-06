using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[RequireComponent(typeof(MinionMover)), RequireComponent(typeof(MinionCollector))]
public class Minion : MonoBehaviour
{
    private MinionMover _minionMover;
    private MinionCollector _minionCollector;
    private Vector3 _targetBase;

    private void Awake()
    {
        _targetBase = transform.GetComponentInParent<Base>().transform.position;
        _minionMover = GetComponent<MinionMover>();
        _minionCollector = GetComponent<MinionCollector>();
    }

    private void OnEnable()
    {
        _minionCollector.ResourceCollected += AssignResourceBase;
    }

    private void OnDisable()
    {
        _minionCollector.ResourceCollected -= AssignResourceBase;
    }

    public void SubmitResource(Resource resource)
    {
        Destroy(resource.gameObject);
    }

    public void GoAfterResource(Resource resource)
    {
        _minionCollector.SetTargetResource(resource);
        _minionMover.SetTargetPosition(resource.transform.position);
    }

    private void AssignResourceBase()
    {
        _minionMover.SetTargetPosition(_targetBase);
    }
}