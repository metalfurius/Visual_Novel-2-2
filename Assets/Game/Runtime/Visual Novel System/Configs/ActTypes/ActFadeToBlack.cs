/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Visual Novel/Acts/Fade to Black", fileName = "New Act Fade to Black")]
public class ActFadeToBlack : ActConfig
{
    // ==================== VARIABLES ===================
    //public float fadeDuration = 1.0f; // Duración de la transición en segundos.

    // ==================== MÉTODOS ====================
    //public override void OnStart()
    //{
       Debug.Log("Start Fade to Black Act");
        Narrator.Instance.FadeToBlack(fadeIn);
    }

    public override void OnEnd()
    {
        Debug.Log("End Fade to Black Act");
        StartCoroutine(FadeToBlack(false)); // Ocultar fondo negro al finalizar.
    }


}*/