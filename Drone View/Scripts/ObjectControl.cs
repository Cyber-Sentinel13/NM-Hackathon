using UnityEngine;
using UnityEngine.UI;

public class ObjectControl : MonoBehaviour
{
    public Slider rotationSlider;    // Reference to the rotation slider
    public Slider scaleSlider;      // Reference to the scale slider
    public GameObject objectToControl; // The 3D object we will manipulate

    private float rotationValue;
    private float scaleValue = 1f;

    void Start()
    {
        // Set initial values
        rotationValue = objectToControl.transform.eulerAngles.y;
        scaleValue = objectToControl.transform.localScale.x;

        // Initialize sliders
        rotationSlider.value = rotationValue;
        scaleSlider.value = scaleValue;

        // Add listeners to sliders
        rotationSlider.onValueChanged.AddListener(OnRotationChanged);
        scaleSlider.onValueChanged.AddListener(OnScaleChanged);
    }

    void Update()
    {
        // Apply rotation and scale in the Update method to continuously update
        objectToControl.transform.rotation = Quaternion.Euler(0, rotationValue, 0);
        objectToControl.transform.localScale = new Vector3(scaleValue, scaleValue, scaleValue);
    }

    // Callback for rotation slider change
    private void OnRotationChanged(float value)
    {
        rotationValue = value * 360f; // Scale slider value to 360 degrees
    }

    // Callback for scale slider change
    private void OnScaleChanged(float value)
    {
        scaleValue = value; // Adjust scale from slider (value is between 0-1)
    }
}
