using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    private float _radius = 200;
    private Queue<Resource> _resources = new Queue<Resource>();

    public bool TryHereResources() => _resources.Count > 0;

    public Resource GetResource()
    {
        Resource resource = _resources.Dequeue();

        while (resource == null)
            resource = _resources.Dequeue();

        return resource;
    }

    public void Scan()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _radius);

        foreach (var collider in colliders)
        {
            if (collider.TryGetComponent<Resource>(out Resource resource) 
                && resource.IsReserved == false 
                && _resources.Contains(resource) == false)
            {
                resource.Reserve();
                _resources.Enqueue((Resource)resource);
            }
        }
    }
}