using System;
using UnityEngine;

public class SpeedEffect: MonoBehaviour
{
    private SpriteRenderer _speedEffect;
    private PlayerVerticalSpeed _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerVerticalSpeed>();
        _player.OnGearChanged += ChangeSpeedEffectStat;
        _speedEffect = GetComponent<SpriteRenderer>();
        _speedEffect.enabled = false;
    }

    private void ChangeSpeedEffectStat(int gear)
    {
        _speedEffect.enabled = gear == 3; 
    }
}
