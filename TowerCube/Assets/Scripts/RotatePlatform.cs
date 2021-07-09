using UnityEngine;

public class RotatePlatform : MonoBehaviour
{
    public float speed=15f;
    private Transform _rotate;

    // Start is called before the first frame update
    void Start()
    {
        _rotate = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        _rotate.Rotate(0, speed * Time.deltaTime, 0);
    }
}
