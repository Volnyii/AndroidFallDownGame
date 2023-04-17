using System;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnSystem: MonoBehaviour
{
    [SerializeField] private CollisionObject[] _objects;
    [SerializeField] private int _howManyObjects;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    [SerializeField] private float _minY;
    [SerializeField] private float _maxY;
    private Player _player;
    private TriggerZone _triggerZone;
    

    private void Awake()
    {
        _triggerZone = FindObjectOfType<TriggerZone>();
        _triggerZone.OnPlayerInside += SpawnObjects;
    }

    private void OnDestroy()
    {
        _triggerZone.OnPlayerInside -= SpawnObjects;
    }

    private void SpawnObjects(CollisionObject collisionObject)
    {
        Vector2 SpawnPos = new Vector2();
        for (int i = 0; i < _howManyObjects; i++)
        {
            var prefabToSpawn = _objects.FirstOrDefault(x => x.ObjectType == collisionObject.ObjectType);
            float _randomForX = Random.Range(_minX, _maxX);
            float _randomForY = Random.Range(_minY, _maxY);
            SpawnPos.x += _triggerZone.transform.position.x + _randomForX;
            SpawnPos.y += _triggerZone.transform.position.y - _randomForY;
            Instantiate(prefabToSpawn, SpawnPos, Quaternion.identity);
            // foreach (var _obj in _objects)
            // {
            //     float _randomForX = Random.Range(_minX, _maxX);
            //     float _randomForY = Random.Range(_minY, _maxY);
            //     SpawnPos.x += _triggerZone.transform.position.x + _randomForX;
            //     SpawnPos.y += _triggerZone.transform.position.y - _randomForY;
            //     Instantiate(_obj, SpawnPos, Quaternion.identity);
            // }
        }
    }
}
