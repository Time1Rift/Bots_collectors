using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private Queue<Minion> _minions = new();
    private Scanner _scanner;

    private void Awake()
    {
        _scanner = GetComponentInParent<Scanner>();
    }

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            _minions.Enqueue(transform.GetChild(i).GetComponent<Minion>());
    }

    private void FixedUpdate()
    {
        GoScan();

        while (_minions.Count > 0 && _scanner.TryHereResources())
        {
            Minion minion = _minions.Dequeue();
            minion.GoAfterResource(_scanner.GetResource());
        }
    }

    public void AddMinion(Minion minion) => _minions.Enqueue(minion);

    private void GoScan()
    {
        if (_scanner.TryHereResources() == false)
            _scanner.Scan();
    }
}