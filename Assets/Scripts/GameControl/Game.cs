using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private ScoreCounter _scoreCounter;

    [Space, SerializeField] private EnemySpawner _enemySpawner;

    [Space, SerializeField] private MissileSpawner _playerMissileSpawner;
    [SerializeField] private MissileSpawner _enemyMissileSpawner;

    [Space, SerializeField] private StartScreen _startScreen;
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
        Time.timeScale = 0;

        _startScreen.Active();
    }

    private void Play()
    {
        _enemySpawner.ReleaseAll();
        _enemyMissileSpawner.ReleaseAll();

        _playerMissileSpawner.ReleaseAll();
        _player.Reset();
        _scoreCounter.Reset();

        _startScreen.Disable();

        Time.timeScale = 1;
    }
}
