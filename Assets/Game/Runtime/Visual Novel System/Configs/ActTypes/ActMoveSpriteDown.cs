using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Visual Novel/Acts/Move Sprite Down", fileName = "New Act Move Sprite Down")]
public class ActMoveSpriteDown : ActConfig
{
    public float moveDistance = 1.0f; // Distancia a mover hacia abajo.
    public float moveDuration = 1.0f; // Duración del movimiento en segundos.

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float startTime;

    public override void OnStart()
    {
        Debug.Log("Start Move Sprite Down Act");

        if (Narrator.Instance.spriteGameObject != null)
        {
            initialPosition = Narrator.Instance.spriteGameObject.transform.position;
            targetPosition = initialPosition - Vector3.up * moveDistance;
            startTime = Time.time;

            // Inicia la corutina para realizar el movimiento gradual.
            Narrator.Instance.StartCoroutine(MoveSprite());
        }
    }

    private IEnumerator MoveSprite()
    {
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration);
            Vector3 newPosition = Vector3.Lerp(initialPosition, targetPosition, t);
            Narrator.Instance.spriteGameObject.transform.position = newPosition;
            yield return null;
        }

        // Cuando el movimiento esté completo, llamamos a NextAct para continuar la narración.
        Narrator.Instance.NextAct();
    }

    public override void OnEnd()
    {
        Debug.Log("End Move Sprite Down Act");
    }
}
