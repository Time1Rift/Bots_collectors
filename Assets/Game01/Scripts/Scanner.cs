using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private LayerMask _resourceMask;
    [SerializeField] private Transform _groupMinions;
    [SerializeField] private  float _radius;

    private List<Minion> _minions = new List<Minion>();

    private void Start()
    {
        for (int i = 0; i < _groupMinions.childCount; i++)
            _minions.Add(_groupMinions.GetChild(i).GetComponent<Minion>());
    }

    private void FixedUpdate()
    {
        List<Collider> hitColliders = new List<Collider>();

        hitColliders.AddRange(Physics.OverlapSphere(transform.position, _radius, _resourceMask));

        for (int i = 0; i < _minions.Count; i++)
        {
            for (int j = 0; j < hitColliders.Count; j++)
            {
                if (_minions[i].IsFree)
                {
                    _minions[i].SetTargetPosition(hitColliders[j].transform.position);
                }
            }
        }
    }
}