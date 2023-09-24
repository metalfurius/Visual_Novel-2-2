using UnityEngine;
using System.Collections;

[CreateAssetMenu(menuName = "Visual Novel/Acts/Move Sprite Down", fileName = "New Act Move Sprite Down")]
public class ActMoveEnableButtons : ActConfig
{
    public float moveDistance = 1.0f; // Distancia a mover hacia abajo.
    public float moveDuration = 1.0f; // Duración del movimiento en segundos.

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float startTime;

    private bool isMoving = false;
    private bool isAtBottom1 = false; // Variable para verificar si el sprite ya está en la posición más baja.

    public override void OnStart()
    {
        Debug.Log("Start Move Sprite Down Act");
        Narrator.Instance.EnableButton1();
        Narrator.Instance.EnableButton2();
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
        Narrator.Instance.DisableButton1();
        Narrator.Instance.DisableButton2();

    }

    // Función pública para mover el sprite hacia arriba.
    public void MoveSpriteUp()
    {
        if (!isMoving && Narrator.Instance.spriteGameObject != null)
        {
            initialPosition = Narrator.Instance.spriteGameObject.transform.position;
            targetPosition = initialPosition + Vector3.up * moveDistance;
            startTime = Time.time;
            isAtBottom1 = false; // El sprite ya no está en la posición más baja.

            // Inicia la corutina para mover el sprite hacia arriba.
            Narrator.Instance.StartCoroutine(MoveSprite());
        }
    }

    // Función pública para mover el sprite hacia abajo.
    public void MoveSpriteDown()
    {
        if (!isMoving && Narrator.Instance.spriteGameObject != null && !isAtBottom1)
        {
            initialPosition = Narrator.Instance.spriteGameObject.transform.position;
            targetPosition = initialPosition - Vector3.up * moveDistance;
            startTime = Time.time;

            // Inicia la corutina para mover el sprite hacia abajo.
            Narrator.Instance.StartCoroutine(MoveSprite());
            isAtBottom1 = true; // El sprite ahora está en la posición más baja.
        }
    }
}
