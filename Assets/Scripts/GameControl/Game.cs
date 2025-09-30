using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Dead += Stop;
    }

    private void OnDisable()
    {
        _player.Dead -= Stop;
    }

    private void Stop()
    {
        Time.timeScale = 0;
    }

    private void Restart()
    {
        _player.Reset();
        Time.timeScale = 1;
    }
}
