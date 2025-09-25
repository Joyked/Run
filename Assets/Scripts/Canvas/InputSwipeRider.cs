using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputSwipeRider : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    public event Action SwipedRight;
    public event Action SwipedLeft;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Math.Abs(eventData.delta.x) > Math.Abs(eventData.delta.y))
        {
            if(eventData.delta.x > 0)
                SwipedRight?.Invoke();
            else
                SwipedLeft.Invoke();
        }
            
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        // Заглушка
    }
}
