﻿using System.Collections;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private float _fadeTime = 1.5f;
    [SerializeField] private Player _player;
    [SerializeField] private float _minZoom;
    [SerializeField] private float _maxZoom;
    private Vector3 _offset;
    private Camera _camera;

    private Coroutine _cameraFade;
    private bool _lastZoomState;
    
    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _offset = transform.position - _player.transform.position;
        _camera = GetComponent<Camera>();
    }
    
    public void SetCameraMinMaxValue(bool zoomIn)
    {
        if (_lastZoomState == zoomIn)
            return;
        
        _lastZoomState = zoomIn;
        var size = zoomIn ? _maxZoom : _minZoom;
        SetCameraSize(size);
    }

    public void SetCameraSize(float size)
    {
        if (_cameraFade != null)
        {
            StopCoroutine(_cameraFade);
        }
        _cameraFade = StartCoroutine(SetOrthographicSizeInternal(size, _fadeTime));
    }

    private IEnumerator SetOrthographicSizeInternal(float size, float time)
    {
        var startValue = _camera.orthographicSize;
        var endValue = size;
        var currentTime = 0f;
        while (currentTime < time)
        {
            _camera.orthographicSize = Mathf.Lerp(startValue, endValue, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        }
    }
    
    private void Update() 
    {        
        transform.position = _player.transform.position + _offset;
    }
}