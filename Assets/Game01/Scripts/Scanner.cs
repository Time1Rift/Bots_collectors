using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private LayerMask _resourceMask;
    [SerializeField] private  float _radius;

    public List<Collider> Scan()
    {
        List<Collider> hitColliders = new List<Collider>();
        List<Collider> resources = new List<Collider>();
        hitColliders.AddRange(Physics.OverlapSphere(transform.position, _radius, _resourceMask));

        for (int i = 0; i < hitColliders.Count; i++)
        {
            if (hitColliders[i].GetComponent<Resource>().IsFound == false)
            {
                hitColliders[i].GetComponent<Resource>().ChangeStatus();
                resources.Add(hitColliders[i]);
            }
        }

        return resources;
    }
}