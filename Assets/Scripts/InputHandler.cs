using System;
using UnityEngine;

public class InputHeandel : MonoBehaviour
{
    public event Action OnIncrease;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            OnIncrease?.Invoke();
    }
}
