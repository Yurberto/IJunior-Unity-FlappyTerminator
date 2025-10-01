using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private ScoreCounter _scoreCounter;

    [SerializeField] private StartCanvas _startCanvas;
    [SerializeField] private Button _playButton;

    private void Start()
    {
        Stop();
    }

    private void OnEnable()
    {
        _player.Dead += Stop;
        _enemySpawner.EnemyDead += _scoreCounter.Add;
        _playButton.onClick.AddListener(Play);
    }

    private void OnDisable()
    {
        _player.Dead -= Stop;
        _enemySpawner.EnemyDead -= _scoreCounter.Add;
        _playButton.onClick.RemoveListener(Play);
    }

    private void Stop()
    {
        _enemySpawner.StopSpawn();

        Time.timeScale = 0;
        _startCanvas.Active();
    }

    private void Play()
    {
        _player.Reset();
        _scoreCounter.Reset();

        Time.timeScale = 1;
        _startCanvas.Disable();

        _enemySpawner.Clear();
        _enemySpawner.StartSpawn();
    }
}
