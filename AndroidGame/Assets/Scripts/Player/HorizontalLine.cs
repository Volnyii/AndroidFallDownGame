using System;
using UnityEngine;

public class HorizontalLine: MonoBehaviour
{
    [SerializeField] private Transform _movingXBody;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;
    public event Action OnChangePlayerXPosition;

    public void ChangePlayerPosition()
    {
        if (_movingXBody.position.x >= _maxX)
        {
            _movingXBody.position = new Vector3(_minX, _movingXBody.position.y);
        }
        else if (_movingXBody.position.x <= _minX)
        {
            _movingXBody.position = new Vector3(_maxX, _movingXBody.position.y);
        }
    }
}
