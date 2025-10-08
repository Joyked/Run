using UnityEngine;
using TMPro;

public class LangInPanel : MonoBehaviour
{
    [SerializeField] private string _rusText;
    [SerializeField] private string _engText;
    
    private TMP_Text _text;

    private void Awake()
    {
        _text = GetComponent<TMP_Text>();

        if (GameStateSDK.HasRussianLocale())
            _text.text = _rusText;
        else
            _text.text = _engText;
    }
}
