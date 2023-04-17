using System;
using UnityEngine;

public class SpeedEffect: MonoBehaviour
{
    [SerializeField] private float _lerpSpeed = 10f;
    
    private SpriteRenderer _speedEffect;
    private Player _player;
    
    private void Awake()
    {
        _player = FindObjectOfType<Player>();
        _speedEffect = GetComponent<SpriteRenderer>();
        _speedEffect.enabled = false;
    }

    private void Update()
    {
        if(_player == null)
            return;
        
        BindToPlayer();
    }

    private void BindToPlayer()
    {
        var yDiff = _player.yDiff;
        var playerPos = _player.transform.position;
        var finalPos = new Vector3(playerPos.x, playerPos.y + yDiff, playerPos.z);
        transform.position = Vector3.Lerp(transform.position, finalPos, _lerpSpeed * Time.deltaTime);
    }

    public void ChangeSpeedEffectStat(bool isSpeedMax)
    {
        _speedEffect.enabled = isSpeedMax; 
    }
}
