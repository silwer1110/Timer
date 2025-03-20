using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private Counter _counter;

    private void OnEnable()
    {
        _counter.ValueChanged += OnCountChanged; 
    }

    private void OnDisable()
    {
        _counter.ValueChanged -= OnCountChanged;
    }

    private void OnCountChanged(int value)
    {
        _text.text = value.ToString();
    }
}