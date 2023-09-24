using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public string ingredientName; // Nombre del ingrediente (por ejemplo, "Tomate", "Carne", etc.)

    public void OnMouseDown()
    {
        // Cuando se hace clic en el ingrediente, intenta agregarlo a la lista de ingredientes.
        CookingManager.Instance.AddIngredient(ingredientName);
    }
}
