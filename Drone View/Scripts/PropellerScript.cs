using UnityEngine;

public class PropellerScript : MonoBehaviour
{
    public float maxRotationSpeed = 1000f; // Max speed during takeoff
    private float currentRotationSpeed = 0f; // Current spinning speed
    private bool isSpinning = false;
    private bool isLanding = false;
    private float decelerationRate = 50f; // Rate at which the propellers slow down during landing

    void Update()
    {
        if (isSpinning)
        {
            // Spin up during takeoff
            if (currentRotationSpeed < maxRotationSpeed)
            {
                currentRotationSpeed += Time.deltaTime * 500f; // Speed up the spinning
            }
            transform.Rotate(Vector3.forward * currentRotationSpeed * Time.deltaTime);
        }
        else if (isLanding)
        {
            // Decelerate during landing
            if (currentRotationSpeed > 0f)
            {
                currentRotationSpeed -= decelerationRate * Time.deltaTime; // Gradually slow down
                transform.Rotate(Vector3.forward * currentRotationSpeed * Time.deltaTime);
            }
            else
            {
                // Stop once speed reaches 0
                currentRotationSpeed = 0f;
            }
        }
    }

    public void StartSpinning()
    {
        isSpinning = true;
        isLanding = false;
    }

    public void StartLanding()
    {
        isLanding = true;
        isSpinning = false;
    }
}
