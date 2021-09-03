using UnityEngine;

public class PlayerFollowWithCamera : MonoBehaviour
{
    [SerializeField] Transform _playerTransform;
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, _playerTransform.position.z-10);
    }
}
