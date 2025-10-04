using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class EnemyShooter : MonoBehaviour
{
    [SerializeField, Range(0.00f, 100.0f)] private float _shootDelay = 1;

    private Shooter _shooter;
    private Coroutine _shootCoroutine;

    public void Initialize(MissileSpawner missileSpawner)
    {
        _shooter.Initialize(missileSpawner);
    }

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
    }

    public void StartShooting()
    {
        if (_shootCoroutine != null)
        {
            StopCoroutine(_shootCoroutine);
            _shootCoroutine = null;
        }

        _shootCoroutine = StartCoroutine(ShootCoroutine());
    }

    private IEnumerator ShootCoroutine()
    {
        var wait = new WaitForSeconds(_shootDelay);

        while (enabled)
        {
            _shooter.Shoot(-transform.right);
            yield return wait;
        }
    }
}
