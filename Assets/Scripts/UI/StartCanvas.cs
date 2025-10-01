using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class StartCanvas : MonoBehaviour
{
    public void Active()
    {
        gameObject.SetActive(true);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
