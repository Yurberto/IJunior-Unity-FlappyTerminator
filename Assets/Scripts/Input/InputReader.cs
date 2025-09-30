using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    public event Action JumpKeyPressed;
    public event Action ShootKeyPressed;

    private void Update()
    {
        if (Input.GetKeyDown(InputData.Jump))
            JumpKeyPressed?.Invoke();

        if (Input.GetKeyDown(InputData.Shoot))
            ShootKeyPressed?.Invoke();
    }
}
