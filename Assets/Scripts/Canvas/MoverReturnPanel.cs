using System;
using UnityEngine;
using DG.Tweening;

public class MoverReturnPanel : MonoBehaviour
{
    private RectTransform _transform;
    private Sequence _sequence;
    
    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
        _sequence = DOTween.Sequence();
    }

    private void OnEnable()
    {
        _sequence.AppendInterval(3f);
        _sequence.Append(_transform.DOAnchorPos(new Vector2(0, -30), 1f));
    }
}
