using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Base : MonoBehaviour
{
    private List<Minion> _minions = new List<Minion>();
    private Scanner _scanner;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            _minions.Add(transform.GetChild(i).GetComponent<Minion>());

        _scanner = transform.GetComponentInParent<Scanner>();
    }

    private void Update()
    {
        for (int i = 0; i < _minions.Count; i++)
        {
            if (_minions[i].IsFree && _scanner.TryHereResources())
                _minions[i].GoAfterResource(_scanner.GetResource());
        }
    }
}