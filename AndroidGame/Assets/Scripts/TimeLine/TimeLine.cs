using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeLine: MonoBehaviour
{
    [SerializeField] private RectTransform _playerIcon;
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private float _doubleSpeed;
    [SerializeField] private float _maxSpeed;
    private float _offset;
    private PlayerVerticalSpeed _playerVerticalSpeed;

    private void Awake()
    {
        _playerVerticalSpeed = FindObjectOfType<PlayerVerticalSpeed>();
        _playerVerticalSpeed.OnGearChanged += PlayerVerticalSpeedOnOnGearChanged;
    }

    private void PlayerVerticalSpeedOnOnGearChanged(int gear)
    {
        switch (gear)
        {
            case 1:
                _offset = _defaultSpeed;
                break;
            case 2:
                _offset = _doubleSpeed;
                break;
            case 3:
                _offset = _maxSpeed;
                break;
        }
    }

    private void ChangePlayerIconPos(float offset)
    {
        _playerIcon.anchoredPosition = new Vector2(0, (float) (_playerIcon.anchoredPosition.y - offset));
    }

    private void Update()
    {
        ChangePlayerIconPos(_offset);
    }
}
