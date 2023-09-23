using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookingManager : MonoBehaviour
{
    public static CookingManager Instance;

    public List<string> ingredientList = new List<string>(); // Lista de ingredientes seleccionados.
    public Text ingredientText; // Referencia al objeto Text que muestra la lista de ingredientes en la pantalla.

    private void Awake()
    {
        Instance = this;
    }

    public void AddIngredient(string ingredientName)
    {
        // Añadir ingredientes a la lista si hay menos de 3.
        if (ingredientList.Count < 3)
        {
            ingredientList.Add(ingredientName);
            UpdateIngredientText();
        }
    }

    public void RemoveLastIngredient()
    {
        // Eliminar el último ingrediente de la lista.
        if (ingredientList.Count > 0)
        {
            ingredientList.RemoveAt(ingredientList.Count - 1);
            UpdateIngredientText();
        }
    }

    private void UpdateIngredientText()
    {
        // Actualizar el texto que muestra la lista de ingredientes en la pantalla.
        string ingredientString = "Ingredientes: ";
        for (int i = 0; i < ingredientList.Count; i++)
        {
            ingredientString += ingredientList[i];
            if (i < ingredientList.Count - 1)
            {
                ingredientString += ", ";
            }
        }
        ingredientText.text = ingredientString;
    }

    public void Cook()
    {
        // Lógica para determinar qué plato se cocina según la lista de ingredientes.
        string dish = DetermineDish();
        Debug.Log("Plato cocinado: " + dish);

        // Avanzar al siguiente acto o realizar acciones adicionales.
        Narrator.Instance.NextAct();
    }

    private string DetermineDish()
    {
        // Lógica para determinar el plato cocinado según la lista de ingredientes.
        // Puedes implementar esta lógica según tus necesidades específicas.
        // Aquí, simplemente devuelve un plato de ejemplo.
        if (ingredientList.Contains("Tomate") && ingredientList.Contains("Carne"))
        {
            return "Espagueti a la Bolognesa";
        }
        else if (ingredientList.Contains("Papa") && ingredientList.Contains("Queso"))
        {
            return "Papas Gratinadas";
        }
        else
        {
            return "Plato No Definido";
        }
    }
}

