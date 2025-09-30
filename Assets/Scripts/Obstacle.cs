using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Obstacle : MonoBehaviour
{
    private void Awake()
    {
        GetComponent<Collider2D>().isTrigger = false;
    }
}

