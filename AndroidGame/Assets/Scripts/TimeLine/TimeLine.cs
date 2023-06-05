using System;
using UnityEngine;
using UnityEngine.UI;

public class TimeLine: MonoBehaviour
{
    [SerializeField] private float _defaultSpeed;
    [SerializeField] private float _doubleSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _totalTime = 120f;

    private PlayerVerticalSpeed _playerVerticalSpeed;
    
    [SerializeField] private Slider _slider;
    
    private float _timeToWork;
    private float _currentTime;
    private float _currentTimeK = 1f;
    private bool _timerStarted;

    public float State => _currentTime / _timeToWork;

    public event Action OnGameWasBegin;
    public event Action OnGameWasEnd;
    
    private void Awake()
    {
        _playerVerticalSpeed = FindObjectOfType<PlayerVerticalSpeed>();
        _playerVerticalSpeed.OnGearChanged += PlayerVerticalSpeedOnOnGearChanged;
        SetUpTimer(_totalTime);
    }

    private void PlayerVerticalSpeedOnOnGearChanged(int gear)
    {
        switch (gear)
        {
            case 1:
                _currentTimeK = _defaultSpeed;
                break;
            case 2:
                _currentTimeK = _doubleSpeed;
                break;
            case 3:
                _currentTimeK = _maxSpeed;
                break;
        }
    }
    
    public void SetUpTimer(float timeToWork)
    {
        _timerStarted = true;
        _currentTimeK = 1f;
        _currentTime = 0;
        _timeToWork = timeToWork;
    }
    
    private void Update()
    {
        if(!_timerStarted)
            return;
        
        _currentTime += Time.deltaTime * _currentTimeK;
        _slider.value = State;

        if (State >= 1f)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        _timerStarted = false;
        OnGameWasEnd?.Invoke();
    }
}
