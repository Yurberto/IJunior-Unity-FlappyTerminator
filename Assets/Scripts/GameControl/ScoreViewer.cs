using TMPro;
using UnityEngine;

[RequireComponent(typeof(ScoreCounter))]
public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private ScoreCounter _scoreCounter;

    private void Awake()
    {
        _scoreCounter = GetComponent<ScoreCounter>();
    }

    private void OnEnable()
    {
        _scoreCounter.ValueChanged += SetScore;
    }

    private void OnDisable()
    {
        _scoreCounter.ValueChanged -= SetScore;
    }

    private void SetScore(int score)
    {
        if (score < 0)
            return;

        _text.text = score.ToString();
    }
}
