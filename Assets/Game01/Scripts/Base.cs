using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Base : MonoBehaviour
{
    private List<Minion> _minions = new List<Minion>();

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            _minions.Add(transform.GetChild(i).GetComponent<Minion>());
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < _minions.Count; i++)
        {
            if (_minions[i].IsFree && transform.GetComponentInParent<Scanner>().TryHereResources())
            {
                Vector3 position = transform.GetComponentInParent<Scanner>().GetTargetPosition();
                _minions[i].SetTargetPosition(position);
            }
        }
    }
}