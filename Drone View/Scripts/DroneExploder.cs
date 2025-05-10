using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneExploder : MonoBehaviour
{
    private Dictionary<Transform, Vector3> originalPositions = new Dictionary<Transform, Vector3>();
    private Dictionary<Transform, Vector3> explodedPositions = new Dictionary<Transform, Vector3>();
    private bool isExploded = false;
    private List<PropellerScript> propellers = new List<PropellerScript>();

    void Start()
    {
        // Add the propellers to a list for easy reference
        propellers.Add(transform.Find("FL_Propeller").GetComponent<PropellerScript>());
        propellers.Add(transform.Find("FR_Propeller").GetComponent<PropellerScript>());
        propellers.Add(transform.Find("BL_Propeller").GetComponent<PropellerScript>());
        propellers.Add(transform.Find("BR_Propeller").GetComponent<PropellerScript>());

        // Store original positions and exploded positions for each part
        foreach (Transform part in transform)
        {
            originalPositions[part] = part.localPosition;
        }

        explodedPositions[transform.Find("FL_Propeller")] = originalPositions[transform.Find("FL_Propeller")] + new Vector3(-0.3f, 0.1f, 0.3f);
        explodedPositions[transform.Find("FR_Propeller")] = originalPositions[transform.Find("FR_Propeller")] + new Vector3(0.3f, 0.1f, 0.3f);
        explodedPositions[transform.Find("BL_Propeller")] = originalPositions[transform.Find("BL_Propeller")] + new Vector3(-0.3f, 0.1f, -0.3f);
        explodedPositions[transform.Find("BR_Propeller")] = originalPositions[transform.Find("BR_Propeller")] + new Vector3(0.3f, 0.1f, -0.3f);
        explodedPositions[transform.Find("Camera")] = originalPositions[transform.Find("Camera")] + new Vector3(0f, -0.1f, 0.2f);
        explodedPositions[transform.Find("Body")] = originalPositions[transform.Find("Body")]; // stays in place
    }

    // Toggle exploded view (previous method)
    public void ToggleExplodedView()
    {
        StopAllCoroutines();
        foreach (Transform part in originalPositions.Keys)
        {
            Vector3 target = isExploded ? originalPositions[part] : explodedPositions[part];
            StartCoroutine(MoveToPosition(part, target));
        }
        isExploded = !isExploded;
    }

    private IEnumerator MoveToPosition(Transform part, Vector3 target)
    {
        float duration = 0.5f;
        float elapsed = 0f;
        Vector3 start = part.localPosition;

        while (elapsed < duration)
        {
            part.localPosition = Vector3.Lerp(start, target, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        part.localPosition = target;
    }

    // New method to handle Takeoff
    public void TakeOff()
    {
        foreach (var propeller in propellers)
        {
            propeller.StartSpinning(); // Start spinning for all propellers
        }
    }

    // New method to handle Landing
    public void Land()
    {
        foreach (var propeller in propellers)
        {
            propeller.StartLanding(); // Start the slow landing deceleration for all propellers
        }
    }
}
