using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    public void Render(int value)
    {
        _text.text = value.ToString();
    }
}
