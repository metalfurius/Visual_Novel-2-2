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

    private bool isMoving = false;

    public override void OnStart()
    {
        Debug.Log("Start Move Sprite Down Act");

        if (Narrator.Instance.spriteGameObject != null)
        {
            initialPosition = Narrator.Instance.spriteGameObject.transform.position;
            targetPosition = initialPosition - Vector3.up * moveDistance;
            startTime = Time.time;

            // Inicia la corutina solo si no estamos ya en movimiento.
            if (!isMoving)
            {
                Narrator.Instance.StartCoroutine(MoveSprite());
            }
        }
    }

    private IEnumerator MoveSprite()
    {
        isMoving = true;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / moveDuration);
            Vector3 newPosition = Vector3.Lerp(initialPosition, targetPosition, t);
            Narrator.Instance.spriteGameObject.transform.position = newPosition;
            yield return null;
        }

        isMoving = false;
        // No llamamos a NextAct aquí, ya que queremos permitir el control manual con botones.
    }

    public override void OnEnd()
    {
        Debug.Log("End Move Sprite Down Act");
    }

    // Función pública para mover el sprite hacia arriba.
    public void MoveSpriteUp()
    {
        if (!isMoving && Narrator.Instance.spriteGameObject != null)
        {
            initialPosition = Narrator.Instance.spriteGameObject.transform.position;
            targetPosition = initialPosition + Vector3.up * moveDistance;
            startTime = Time.time;

            // Inicia la corutina para mover el sprite hacia arriba.
            Narrator.Instance.StartCoroutine(MoveSprite());
        }
    }

    // Función pública para mover el sprite hacia abajo.
    public void MoveSpriteDown()
    {
        if (!isMoving && Narrator.Instance.spriteGameObject != null)
        {
            initialPosition = Narrator.Instance.spriteGameObject.transform.position;
            targetPosition = initialPosition - Vector3.up * moveDistance;
            startTime = Time.time;

            // Inicia la corutina para mover el sprite hacia abajo.
            Narrator.Instance.StartCoroutine(MoveSprite());
        }
    }
}
