using UnityEngine;
using UnityEngine.UI;

public class ButtonHandlerActMoveSpriteDown : MonoBehaviour
{
    public ActMoveSpriteDown moveSpriteAct; // Referencia al acto ActMoveSpriteDown.

    // Llama a la función pública MoveSpriteUp del ActMoveSpriteDown.
    public void MoveSpriteUp()
    {
    moveSpriteAct.MoveSpriteUp(); 
    }

    // Llama a la función pública MoveSpriteDown del ActMoveSpriteDown.
    public void MoveSpriteDown()
    {
    moveSpriteAct.MoveSpriteDown();
    }
}
