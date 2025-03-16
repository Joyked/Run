using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class NextPlayer : MonoBehaviour
{
    [SerializeField] private GameObject[] _modelPrefabs;

    private GameObject _model;
    private int _indexModel;
    private TuchButton _button;

    public void Initialize(TuchButton button)
    {
        _button = button;
        _button.ButtonPressed += ChangeModel;
        _indexModel = Random.Range(0, _modelPrefabs.Length);
        ChangeModel();
    }

    private void OnDisable() => _button.ButtonPressed -= ChangeModel;

    private void ChangeModel()
    {
        Destroy(_model);
        _model = Instantiate(_modelPrefabs[_indexModel], transform);
        _indexModel = _indexModel >= _modelPrefabs.Length - 1 ? 0 : _indexModel + 1;
    }
}
