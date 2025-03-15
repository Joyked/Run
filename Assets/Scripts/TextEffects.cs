using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class TextEffects : MonoBehaviour
{
    [SerializeField] private float _maxSize;
    [SerializeField] private float _minSize;
    [SerializeField] private float _stepSize;
    
    private TMP_Text _text;
    private bool _textIsMaxSize;
    private bool _textIsGeenColor;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();
    }

    private void FixedUpdate()
    {
        Resize();
        Recolor();
    }

    private void Resize()
    {
        if (_text.fontSize < _maxSize && !_textIsMaxSize)
        {
            _text.fontSize += _stepSize;
            
            if (_text.fontSize >= _maxSize)
                _textIsMaxSize = true;
        }
        else if (_text.fontSize > _minSize && _textIsMaxSize)
        {
            _text.fontSize -= _stepSize;
            
            if (_text.fontSize <= _minSize)
                _textIsMaxSize = false;
        }
    }

    private void Recolor()
    {
        Color color = _text.color;
        color.r += Random.Range(-0.03f , 0.03f);
        color.g += Random.Range(-0.03f , 0.03f);
        color.b += Random.Range(-0.03f , 0.03f);
        _text.color = color;
    }
}
