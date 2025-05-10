using UnityEngine;

public class ClickableProductButton : MonoBehaviour
{
    public int productIndex;              // Which product it represents (0 = bike, 1 = car)
    public ProductManager manager;        // Reference to the main script

    void OnMouseDown()  // Triggered when object is clicked
    {
        manager.SelectProduct(productIndex);  // Call the product manager
    }
}
