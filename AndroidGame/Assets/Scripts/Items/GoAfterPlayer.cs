using System;
using UnityEngine;

public class GoAfterPlayer: MonoBehaviour
{
    private Transform _playerSensors;
    [SerializeField] private Transform _playerPosition;

    private void Awake()
    {
        _playerSensors = GetComponent<Transform>();
    }

    private void Update()
    {
        _playerSensors.position = new Vector3(_playerPosition.position.x, _playerSensors.position.y);
    }
}
