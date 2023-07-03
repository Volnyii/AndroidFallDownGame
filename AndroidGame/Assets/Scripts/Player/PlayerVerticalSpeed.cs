using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVerticalSpeed: MonoBehaviour
{
    [SerializeField] private int _speedMaxValue; 
    [SerializeField] private int _speedForCamScale;
    [SerializeField] private int _speedForEffect;

    private TriggerZone _triggerZone;
    [SerializeField] private float _speedCounter;
    public event Action<int> OnGearChanged;

    [SerializeField] private int _gear;
    
    private void Start()
    {   _triggerZone = FindObjectOfType<TriggerZone>(true);
        _gear = 1;
        OnGearChanged?.Invoke(_gear);
        _triggerZone.OnPlayerInside += SpeedIncreased;
    }

    private void SpeedIncreased(GameItem gameItem)
    {
        if (gameItem.ObjectType == ObjectType.Airplane)
        {
            _speedCounter = 0;
            _gear = 1;
            OnGearChanged?.Invoke(_gear);
        }
    }

    private void Update()
    {
        _speedCounter += Time.deltaTime;
        if (_speedCounter >= _speedForCamScale && _gear == 1)
        {
            _gear = 2;
            OnGearChanged?.Invoke(_gear);
        }

        if (_speedCounter >= _speedForEffect && _gear == 2)
        {
            _gear = 3;
            OnGearChanged?.Invoke(_gear);
        }
        if (_speedCounter > _speedMaxValue)
            _speedCounter = _speedMaxValue;
    }
}
