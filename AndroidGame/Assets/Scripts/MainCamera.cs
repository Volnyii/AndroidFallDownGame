using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private float _flequencyNewValue = 5f;
    [SerializeField] private float _fadeTime = 1.5f;
    [SerializeField] private SpriteRenderer _player;
    [SerializeField] private float _minZoom;
    [SerializeField] private float _maxZoom;
    private Vector3 _offset;
    private Camera _camera;
    private float _flequencyOldValue = 1f;
    private PlayerVerticalSpeed _playerVerticalSpeed;

    private Coroutine _cameraFade;
    private bool _lastZoomState;

    private CinemachineBasicMultiChannelPerlin _nc;
    private CinemachineVirtualCamera _currentVC;

    public event Action OnCameraWasChanged;
    
    private void OnEnable()
    {
        _playerVerticalSpeed = FindObjectOfType<PlayerVerticalSpeed>();
        _playerVerticalSpeed.OnGearChanged += SetCameraMinMaxValue;
        _offset = transform.position - _player.transform.position;
        _camera = GetComponent<Camera>();
    }

    private void OnDisable()
    {
        _playerVerticalSpeed.OnGearChanged -= SetCameraMinMaxValue;
    }

    private void Start()
    {
        var cameraBrain = FindObjectOfType<CinemachineBrain>();
        _currentVC = cameraBrain.ActiveVirtualCamera as CinemachineVirtualCamera;
        _nc = _currentVC.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void SetCameraMinMaxValue(int gear)
    {
        bool zoomIn = gear >= 2;
        if (_lastZoomState == zoomIn)
            return;
        
        _lastZoomState = zoomIn;
        var size = zoomIn ? _maxZoom : _minZoom;
        _nc.m_FrequencyGain = zoomIn ? _flequencyNewValue : _flequencyOldValue;
        SetCameraSize(size);
    }

    private void SetCameraSize(float size)
    {
        OnCameraWasChanged?.Invoke();
        if (_cameraFade != null)
        {
            StopCoroutine(_cameraFade);
        }
        _cameraFade = StartCoroutine(SetOrthographicSizeInternal(size, _fadeTime));
    }

    private IEnumerator SetOrthographicSizeInternal(float size, float time)
    {
        var startValue = _currentVC.m_Lens.OrthographicSize;
        var endValue = size;
        var currentTime = 0f;
        while (currentTime < time)
        {
            OnCameraWasChanged?.Invoke();
            _currentVC.m_Lens.OrthographicSize = Mathf.Lerp(startValue, endValue, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        }
        OnCameraWasChanged?.Invoke();
    }
}
