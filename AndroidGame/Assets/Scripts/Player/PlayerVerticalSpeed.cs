using System;
using UnityEngine;

public class PlayerSpeed: MonoBehaviour
{
    [SerializeField] private int _speedMaxValue; 
    [SerializeField] private int _speedForCamScale;
    [SerializeField] private int _speedForEffect;
    
    private TriggerZone _triggerZone;
    private MainCamera _camera;
    private SpeedEffect _speedEffect;
    private int _speedCounter;
    
    private bool speedEffectActive => _speedCounter >= _speedForEffect; 
    private bool zoomCameraStat => _speedCounter >= _speedForCamScale;

    private void Awake()
    {   _speedEffect = FindObjectOfType<SpeedEffect>();
        _camera = FindObjectOfType<MainCamera>();
        _triggerZone = FindObjectOfType<TriggerZone>();
        _triggerZone.OnPlayerInside += SpeedIncreased;
    }

    private void SpeedIncreased(GameItem gameItem)
    {
        if (gameItem.ObjectType == ObjectType.Airplane)
        {
            _speedCounter = 0;
        }
    }

    private void Update()
    {
        _camera.SetCameraMinMaxValue(zoomCameraStat);
        _speedEffect.ChangeSpeedEffectStat(speedEffectActive);
        
        _speedCounter += 1;
        if (_speedCounter > _speedMaxValue)
            _speedCounter = _speedMaxValue;
    }
}
