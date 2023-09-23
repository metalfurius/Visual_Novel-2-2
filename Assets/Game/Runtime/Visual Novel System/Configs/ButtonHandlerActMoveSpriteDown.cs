using UnityEngine;
using UnityEngine.UI;

public class ButtonHandlerActMoveSpriteDown : MonoBehaviour
{
    public ActMoveSpriteDown moveSpriteAct; // Referencia al acto ActMoveSpriteDown que deseas ejecutar.

    private void Start()
    {
        Button button = GetComponent<Button>(); // Obtén una referencia al componente Button en el mismo GameObject.
        if (button != null && moveSpriteAct != null)
        {
            button.onClick.AddListener(ExecuteMoveSpriteDown); // Agrega un listener para el evento de clic en el botón.
        }
    }

    private void ExecuteMoveSpriteDown()
    {
        // Ejecuta el acto ActMoveSpriteDown cuando se haga clic en el botón.
        moveSpriteAct.OnStart();
    }
}
