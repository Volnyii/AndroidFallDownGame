using System;
using UnityEngine;

public class HorizontalLine: MonoBehaviour
{
    [SerializeField] private Transform _movingXBody;
    [SerializeField] private Camera _camera;
    [SerializeField] private MainCamera _camChangedPos;

    private float _leftBorderX;
    private float _rightBorderX;

    private void Awake()
    {
        OnNeedToRecalcBorders();
        _camChangedPos.OnCameraWasChanged += OnNeedToRecalcBorders;
    }

    private void OnNeedToRecalcBorders()
    {
        _leftBorderX = _camera.ScreenToWorldPoint(new Vector3(0f, 0f, 0f)).x;
        _rightBorderX = _camera.ScreenToWorldPoint(new Vector3(Screen.width, 0f, 0f)).x;   
    }
    
    private void Update()
    {
        if (_movingXBody.position.x >= _rightBorderX)
        {
            _movingXBody.position = new Vector3(_leftBorderX, _movingXBody.position.y);
        }
        else if (_movingXBody.position.x <= _leftBorderX)
        {
            _movingXBody.position = new Vector3(_rightBorderX, _movingXBody.position.y);
        }
    }
}
