using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SpawnResources : MonoBehaviour
{
    [SerializeField] private Resource _resource;
    [SerializeField] private float _timeBetweenSpawn;

    private Coroutine _createResource;
    private BoxCollider _boxCollider;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
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
        float height = 0.3f;

        while (enabled)
        {
            Vector3 position = new Vector3(Random.Range(0, _boxCollider.size.x), height, Random.Range(0, _boxCollider.size.z));
            Instantiate(_resource, position, Quaternion.identity);
            yield return interval;
        }
    }
}