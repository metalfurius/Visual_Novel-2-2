using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class Dish
{
    public string dishName;
    public List<string> dishIngredients;
}


public class CookingManager : MonoBehaviour
{
    public static CookingManager Instance;

    public List<Dish> dishes;
    [SerializeField] Button[] cookingButtons;

    public List<string> ingredientList = new List<string>(); // Lista de ingredientes seleccionados.
    public TextMeshProUGUI ingredientText; // Referencia al objeto Text que muestra la lista de ingredientes en la pantalla.
    
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Debug.Log(DetermineDish(ingredientList));
    }
    public void AddIngredient(string ingredientName)
    {
        // Añadir ingredientes a la lista si hay menos de 3.
        if (ingredientList.Count < 3)
        {
            ingredientList.Add(ingredientName);
            UpdateIngredientText();
            Debug.Log("Clicked");
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
        string dish = DetermineDish(ingredientList);
        Debug.Log("Plato cocinado: " + dish);
        //Limpia la lista de ingredientes y lo deja preparado para hacer el siguiente plato
        ResetCookTable();
        // Avanzar al siguiente acto o realizar acciones adicionales.
        Narrator.Instance.NextAct();
    }

    private void ResetCookTable()
    {
        ingredientList.Clear();
        UpdateIngredientText();
    }
    public void AbleCookingButtons(bool able)
    {
        foreach(Button button in cookingButtons)
        {
            button.interactable = able;
        }
    }
    private string DetermineDish(List<string> ingrdients)
    {
        // Lógica para determinar el plato cocinado según la lista de ingredientes.
        // Puedes implementar esta lógica según tus necesidades específicas.
        // Aquí, simplemente devuelve un plato de ejemplo.

        int correct = 0;
        for (int i = 0; i < dishes.Count; i++) //Itera sobre todas las recetas que hay
        {

            for (int x = 0; x < dishes[i].dishIngredients.Count; x++)//Itera sobre cada ingrediente de la receta
            {
                if (!ingrdients.Contains(dishes[i].dishIngredients[x])) break; //Si no contiene el ingrediente de la receta el plato hecho sale del bucle
                else correct++;
            }

            if (correct == dishes[i].dishIngredients.Count) return dishes[i].dishName; //si contiene todos los ingredientes devuelve
            else correct = 0;
        }
        return "Plato pocho";

       
    }
}

