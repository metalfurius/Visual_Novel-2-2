using UnityEngine;
using UnityEngine.UI;

public class DeleteButton : MonoBehaviour
{
    public Button deleteButton;

    private void Start()
    {
        deleteButton.onClick.AddListener(DeleteIngredient);
    }

    private void DeleteIngredient()
    {
        CookingManager.Instance.RemoveLastIngredient();
    }
}

