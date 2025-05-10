using UnityEngine;
using UnityEngine.UI;

public class ProductManager : MonoBehaviour
{
    public GameObject[] productPrefabs;       // Prefabs to spawn (Bike, Car)
    public Transform displayPoint;            // Where product appears
    public GameObject mainMenuCanvas;         // UI menu canvas
    public GameObject backButton;             // Back UI button
    public GameObject controlPanel;           // Panel with Rotate/Explode/Color buttons

    private GameObject currentProduct;        // The spawned product

    public void LoadProduct(int index)
    {
        // Hide UI menu
        mainMenuCanvas.SetActive(false);

        // Destroy old object if already showing
        if (currentProduct != null)
            Destroy(currentProduct);

        // Spawn selected prefab
        currentProduct = Instantiate(productPrefabs[index], displayPoint.position, Quaternion.identity);

        // Show Back and control buttons
        backButton.SetActive(true);
        controlPanel.SetActive(true);
    }

    public void BackToMenu()
    {
        // Destroy the currently shown product
        if (currentProduct != null)
            Destroy(currentProduct);

        // Show main menu again
        mainMenuCanvas.SetActive(true);

        // Hide Back and control buttons
        backButton.SetActive(false);
        controlPanel.SetActive(false);
    }
}
