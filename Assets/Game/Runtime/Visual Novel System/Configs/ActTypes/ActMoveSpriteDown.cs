using UnityEngine;

[CreateAssetMenu(menuName = "Visual Novel/Acts/Move Sprite Down", fileName = "New Act Move Sprite Down")]
public class ActMoveSpriteDown : ActConfig
{
    public float moveDistance = 1.0f; // Distancia a mover hacia abajo.

    public override void OnStart()
    {
        Debug.Log("Start Move Sprite Down Act");
        // Agrega el código para mover el Sprite aquí.
        if (Narrator.Instance.spriteGameObject != null)
        {
            Vector3 newPosition = Narrator.Instance.spriteGameObject.transform.position - Vector3.up * moveDistance;
            Narrator.Instance.spriteGameObject.transform.position = newPosition;
        }
        // Llama a NextAct para continuar la narración.
        Narrator.Instance.NextAct();
    }

    public override void OnEnd()
    {
        Debug.Log("End Move Sprite Down Act");
    }
}
