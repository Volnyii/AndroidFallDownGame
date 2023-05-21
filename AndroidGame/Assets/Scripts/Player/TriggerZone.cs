using System;
using UnityEngine;

public class TriggerZone: MonoBehaviour
{
    public event Action<GameItem> OnPlayerInside;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        var objInside = obj.gameObject.GetComponent<GameItem>();
        if (objInside != null)
        {
            OnPlayerInside?.Invoke(objInside);
        }
    }
}
