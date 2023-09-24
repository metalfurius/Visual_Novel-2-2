using UnityEngine;
using UnityEngine.UI;

public class ButtonHandlerActMoveSpriteDown : MonoBehaviour
{
    public ActMoveEnableButtons moveSpriteAct; // Referencia al acto ActMoveSpriteDown.

    // Llama a la función pública MoveSpriteUp del ActMoveSpriteDown.
    public void MoveSpriteUp()
    {
        moveSpriteAct.MoveSpriteUp();
        CookingManager.Instance.AbleCookingButtons(false);
    }

    // Llama a la función pública MoveSpriteDown del ActMoveSpriteDown.
    public void MoveSpriteDown()
    {
         moveSpriteAct.MoveSpriteDown();
         CookingManager.Instance.AbleCookingButtons(true);

    }
}
