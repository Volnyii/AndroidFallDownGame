using System;
using UnityEngine;
using UnityEngine.EventSystems;
public class InputPanel : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public event Action<float> OnDragEvent;

    public void OnDrag(PointerEventData eventData)
    {
        var deltaX = eventData.delta.x;
        OnDragEvent?.Invoke(deltaX);
    }
    
    public void OnEndDrag(PointerEventData eventData)
    {
        OnDragEvent?.Invoke(0f);
    }
}
