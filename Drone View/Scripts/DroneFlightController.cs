using UnityEngine;

public class DroneFlightController : MonoBehaviour
{
    public float flightHeight = 5f;
    public float speed = 1f;

    private bool isTakingOff = false;
    private bool isLanding = false;

    private Vector3 groundPosition;
    private Vector3 targetPosition;

    void Start()
    {
        groundPosition = transform.position;
        targetPosition = groundPosition + Vector3.up * flightHeight;
    }

    void Update()
    {
        if (isTakingOff)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
                isTakingOff = false;
        }

        if (isLanding)
        {
            transform.position = Vector3.MoveTowards(transform.position, groundPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, groundPosition) < 0.01f)
                isLanding = false;
        }
    }

    public void StartTakeOff()
    {
        isTakingOff = true;
        isLanding = false;
    }

    public void StartLanding()
    {
        isLanding = true;
        isTakingOff = false;
    }
}
