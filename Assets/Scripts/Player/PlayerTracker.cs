using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField, Range(-10.0f, 10.0f)] private float _offset = 4.5f; 

    private void Update()
    {
        transform.position = new Vector3 (_player.transform.position.x + _offset, transform.position.y, transform.position.z);
    }
}
