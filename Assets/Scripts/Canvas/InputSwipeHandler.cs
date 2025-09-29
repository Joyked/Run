using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputSwipeHandler : MonoBehaviour, IBeginDragHandler, IDragHandler
{
    private bool _hasGameStarted = false;
    
    public event Action OnGameStart;
    public event Action SwipedRight;
    public event Action SwipedLeft;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (Math.Abs(eventData.delta.x) > Math.Abs(eventData.delta.y))
        {
            if(eventData.delta.x > 0)
                SwipedRight?.Invoke();
            else
                SwipedLeft?.Invoke();
            
            if (!_hasGameStarted)
            {
                OnGameStart?.Invoke();
                _hasGameStarted = true;
            }
        }
    }

    public void OnDrag(PointerEventData pointerEventData)
    {
        // Заглушка
    }
}
