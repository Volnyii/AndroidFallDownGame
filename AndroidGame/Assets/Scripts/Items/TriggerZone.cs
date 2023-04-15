using System;
using UnityEngine;

public class TriggerZone: MonoBehaviour
{
    private SpawnSystem _spawnObjects;
    [SerializeField] private bool _isTriggered;

    private void Awake()
    {
        _spawnObjects = FindObjectOfType<SpawnSystem>();
        _isTriggered = true;
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.GetComponent<CollisionObject>() && _isTriggered)
        {
            _spawnObjects.SpawnObjects();
            _isTriggered = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _isTriggered = true;
    }
}
