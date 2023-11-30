using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnResources : MonoBehaviour
{
    [SerializeField] private Resource _resource;
    [SerializeField] private float _timeBetweenSpawn;

    private Transform[] _points;
    private Coroutine _createResource;

    private void Start()
    {
        _points = new Transform[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
            _points[i] = transform.GetChild(i);
        
        _createResource = StartCoroutine(CreateResource());
    }

    private void OnDisable()
    {
        if (_createResource != null)
            StopCoroutine(_createResource);
    }

    private IEnumerator CreateResource()
    {
        var interval = new WaitForSecondsRealtime(_timeBetweenSpawn);

        while (enabled)
        {
            int index = Random.Range(0, transform.childCount);
            Instantiate(_resource, _points[index].position, Quaternion.identity);
            yield return interval;
        }
    }
}