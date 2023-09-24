using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Visual Novel/Acts/Fade to Black", fileName = "New Act Fade to Black")]
public class ActFadeToBlack : ActConfig
{
    // ==================== VARIABLES ===================
    public string TriggerKey;

    // ==================== MÉTODOS ====================
    public override void OnStart()
    {
        Debug.Log("Start Fade to Black Act");
        Narrator.Instance.Fade(TriggerKey);
        Narrator.Instance.NextAct();
    }

    public override void OnEnd()
    {
        Debug.Log("End Fade");
    }


}