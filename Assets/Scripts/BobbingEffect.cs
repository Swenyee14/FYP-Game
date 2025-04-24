using UnityEngine;

public class BobbingEffect : MonoBehaviour
{
    public float amplitude = 0.1f; // How much it moves up and down
    public float frequency = 1f;   // How fast it bobs

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float newY = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPos.x, startPos.y + newY, startPos.z);
    }
}
