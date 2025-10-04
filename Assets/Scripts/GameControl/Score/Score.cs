using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private ScoreCounter _counter;
    [SerializeField] private ScoreViewer _viewer;

    private void OnEnable()
    {
        _counter.ValueChanged += _viewer.Render;
    }

    private void OnDisable()
    {
        _counter.ValueChanged += _viewer.Render;
    }
}
