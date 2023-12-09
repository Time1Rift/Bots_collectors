using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(BaseScanner))]
public class Base : MonoBehaviour
{
    private Queue<Minion> _minions = new Queue<Minion>();
    private BaseScanner _scanner;

    private void Awake()
    {
        _scanner = GetComponent<BaseScanner>();
    }

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            _minions.Enqueue(transform.GetChild(i).GetComponent<Minion>());
    }

    private void Update()
    {
        GoScan();

        while (_minions.Count > 0 && _scanner.TryHereResources())
        {
            Minion minion = _minions.Dequeue();
            minion.GoAfterResource(_scanner.GetResource());
        }
    }

    public void AddMinion(Minion minion)
    {
        _minions.Enqueue(minion);
    }

    private void GoScan()
    {
        if (_scanner.TryHereResources() == false)
            _scanner.Scan();
    }
}