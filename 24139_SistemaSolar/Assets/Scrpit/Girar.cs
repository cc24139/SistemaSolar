using UnityEngine;

public class Girar : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform centerRotation;
    public float speed = 1f;
    void Start()
    {
        if (centerRotation == null)
        {
            centerRotation = this.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(centerRotation.position, Vector3.up, speed * Time.deltaTime);
    }
}
