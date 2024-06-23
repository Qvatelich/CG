using UnityEngine;

public class SkyMove : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void Start()
    {
        _speed = Random.Range(0f, 6f);
    }

    private void FixedUpdate()
    {
        float moveDistance = _speed * Time.deltaTime;
        transform.Translate(Vector3.right * moveDistance);

        if (transform.position.x >= 12)
        {
            Destroy(gameObject);
        }
    }
}
