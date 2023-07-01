using System;
using UnityEngine;
using UnityEngine.UI;

public class ParallaxObjects : MonoBehaviour
{
    [SerializeField] private Transform _playerBody;
    [SerializeField] private float _parallaxYSpeed;
    [SerializeField] private float _parallaxfactor = 0.5f;
    [SerializeField] private float _index = 0.01f;

    private Transform _transformParallaxObject;

    private Vector3 _startPosition;
    private Vector3 _offsetFromPlayer => _playerBody.position - transform.position;

    private void Awake()
    {
        _transformParallaxObject = GetComponent<Transform>();
        _startPosition = transform.position;
    }

    private void Update()
    {
        var newV = _startPosition + _offsetFromPlayer * _parallaxfactor; //todo что-то тут не так
        _transformParallaxObject.position = new Vector3(newV.x, _transformParallaxObject.position.y + (_parallaxYSpeed * _index));
    }
}
