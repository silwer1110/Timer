using System;
using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputHeandel _inputHeandel;

    private bool _isRunning = false;
    private Coroutine _countCoroutine;
    private int _currentTime = 0;
    public Action<int> ValueChanged;

    private void OnEnable()
    {
        _inputHeandel.OnIncrease += ToggleTimer;
    }

    private void OnDisable()
    {
        _inputHeandel.OnIncrease -= ToggleTimer;
    }

    private void ToggleTimer()
    {
        if (_isRunning)
        {
            if (_countCoroutine != null)
                StopCoroutine(_countCoroutine);
        }
        else
        {
            _countCoroutine = StartCoroutine(CountUp(0.5f));
        }

        _isRunning = !_isRunning;
    }

    private IEnumerator CountUp(float delay)
    {
        WaitForSeconds wait = new WaitForSeconds(delay);

        while (enabled)
        {
            ValueChanged?.Invoke(_currentTime);
            _currentTime++;

            yield return wait;
        }
    }
}