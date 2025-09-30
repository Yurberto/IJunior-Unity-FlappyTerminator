using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ReleaseZone : MonoBehaviour 
{
    private void Start()
    {
        GetComponent<Collider2D>().isTrigger = true;
    }
}
