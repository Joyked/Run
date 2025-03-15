using System;
using UnityEngine;
using UnityEngine.UI;

public class TuchButton : MonoBehaviour
{
    public event Action ButtonPressed;

    private Button _button;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ProcessClick);
    }

    private void ProcessClick()
    {
        ButtonPressed?.Invoke();
    }
}
