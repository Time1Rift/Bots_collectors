using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Base : MonoBehaviour
{
    private Queue<Minion> _minions = new Queue<Minion>();
    private Scanner _scanner;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            _minions.Enqueue(transform.GetChild(i).GetComponent<Minion>());

        _scanner = transform.GetComponentInParent<Scanner>();
    }

    private void Update()
    {
        if(_scanner.TryHereResources() == false)
            _scanner.Scan();

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
}