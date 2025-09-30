using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action JumpKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(InputData.Jump))
            JumpKeyPressed?.Invoke();
    }
}
