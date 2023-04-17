using System;
using UnityEngine;

public class TriggerZone: MonoBehaviour
{
    public event Action<CollisionObject> OnPlayerInside;

    private void OnTriggerEnter2D(Collider2D obj)
    {
        var objInside = obj.gameObject.GetComponent<CollisionObject>();
        if (objInside != null)
        {
            OnPlayerInside?.Invoke(objInside);
        }
    }
}
