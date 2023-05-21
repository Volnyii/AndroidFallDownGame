using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeLine: MonoBehaviour
{
    [SerializeField] private RectTransform _playerIcon;
    [SerializeField] private double _defaultSpeed;
    [SerializeField] private double _doubleSpeed;
    [SerializeField] private double _maxSpeed;
    private double offset;
    private PlayerVerticalSpeed _playerVerticalSpeed;

    private void Awake()
    {
        _playerVerticalSpeed = FindObjectOfType<PlayerVerticalSpeed>();
    }

    private void ChangePlayerIconPos(double offset)
    {
        _playerIcon.anchoredPosition = new Vector2(0, (float) (_playerIcon.anchoredPosition.y - offset));
    }

    private double SetOffset()
    {
        if (600 <= _playerVerticalSpeed.SpeedCounter && 
            _playerVerticalSpeed.SpeedCounter < 1200)
        {
            offset = _doubleSpeed;
        }
        else if (_playerVerticalSpeed.SpeedCounter == 1200)
        {
            offset = _maxSpeed;
        }
        else
        {
            offset = _defaultSpeed;
        }
        return offset;
    }

    private void Update()
    {
        offset = SetOffset();
        ChangePlayerIconPos(offset);
    }
}
