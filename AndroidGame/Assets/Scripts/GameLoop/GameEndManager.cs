using System;
using UnityEngine;
using UnityEngine.UI;

public class GameEndManager: MonoBehaviour
{
    private TimeLine _timeLine;
    [SerializeField] private ParallaxObjects[] _parallaxObjects;
    [SerializeField] private Player _player;

    private void Awake()
    {
        _timeLine = FindObjectOfType<TimeLine>();
        _timeLine.OnGameWasEnd += DeleteAllItems;
    }

    private void DeleteAllItems()
    {
        if (_player != null)
        {
            Destroy(_player.gameObject, 5);
        } 
        
        foreach (var obj in _parallaxObjects)
        {
            if(obj != null) 
                Destroy(obj.gameObject);
        }
    }
}
