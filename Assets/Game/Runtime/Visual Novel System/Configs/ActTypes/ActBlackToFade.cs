using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Visual Novel/Acts/BlackToFade", fileName = "New Act BlackToFade")]
public class ActBlackToFade : ActConfig
{
    // ==================== VARIABLES ===================
    public string TriggerKey;

    // ==================== MÉTODOS ====================
    public override void OnStart()
    {
        Debug.Log("Start Fade to Black Act");
        Narrator.Instance.FadeOut(TriggerKey);
        Narrator.Instance.NextAct();
    }

    public override void OnEnd()
    {
        Debug.Log("End Fade");
    }


}