using System;
using UnityEngine;

public class SpeedEffect: MonoBehaviour
{
    private SpriteRenderer _speedEffect;

    private void Awake()
    {
        _speedEffect = GetComponent<SpriteRenderer>();
        _speedEffect.enabled = false;
    }

    public void ChangeSpeedEffectStat(bool isSpeedMax)
    {
        _speedEffect.enabled = isSpeedMax; 
    }
}
