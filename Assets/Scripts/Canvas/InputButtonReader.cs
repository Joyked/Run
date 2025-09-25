using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class InputButtonReader : MonoBehaviour
{
    private Button _button;

    public event Action ButtonPressed;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(HandleClick);
    }

    private void HandleClick() =>
        ButtonPressed?.Invoke();
}