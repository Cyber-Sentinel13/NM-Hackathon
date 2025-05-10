using UnityEngine;

public class SpinPropeller : MonoBehaviour
{
    public float spinSpeed = 1000f;

    void Update()
    {
        transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);
    }
}
