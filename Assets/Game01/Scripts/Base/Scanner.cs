using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    private float _radius = 200;
    private Queue<Resource> _resourcesDetected = new();
    private List<Resource> _resourcesReserved = new();

    public bool TryHereResources() => _resourcesDetected.Count > 0;

    public Resource GetResource()
    {
        Resource resource = _resourcesDetected.Dequeue();

        while (resource == null)
            resource = _resourcesDetected.Dequeue();

        _resourcesReserved.Add(resource);
        return resource;
    }

    public void Scan()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<Resource>(out Resource resource) 
                && _resourcesDetected.Contains(resource) == false
                && _resourcesReserved.Contains(resource) == false)
            {
                    _resourcesDetected.Enqueue((Resource)resource);
            }
        }

        CanResourcesReserved();
    }

    private void CanResourcesReserved()
    {
        for (int i = 0; i < _resourcesReserved.Count; i++)
        {
            if (_resourcesReserved[i] == null)
                _resourcesReserved.Remove(_resourcesReserved[i]);
        }
    } 
}