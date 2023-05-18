using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class ItemsSpawnSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] _spawnItems;
    [SerializeField] private Transform _leftSideCorner;
    [SerializeField] private Transform _rightSideCorner;
    [SerializeField] private float _yToDespawn;

    private List<GameObject> _spawnedList = new List<GameObject>();
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Spawn();
        }

        foreach (var item in _spawnedList.ToList())
        {
            if (item.transform.position.y > _yToDespawn)
            {
                var goToDestroy = item;
                _spawnedList.Remove(item);
                Destroy(goToDestroy);
            }
        }
    }

    private void Spawn()
    {
        var itemToSpawn = _spawnItems[Random.Range(0, _spawnItems.Length-1)];
        var positionToSpawn = new Vector3(Random.Range(_leftSideCorner.position.x, _rightSideCorner.position.x), _leftSideCorner.position.y, 0);
        var instance = Instantiate(itemToSpawn, positionToSpawn, Quaternion.identity);
        _spawnedList.Add(instance);
    }
}
