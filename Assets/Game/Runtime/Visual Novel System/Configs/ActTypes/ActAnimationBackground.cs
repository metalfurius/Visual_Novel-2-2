using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Visual Novel/Acts/AnimB", fileName = "New Act AnimB")]
public class ActAnimationBackground : ActConfig {
    // ==================== VARIABLES ===================
    public string TriggerKey;

    // ==================== METODOS ====================
    public override void OnStart() {
        Debug.Log("Start AnimB Act");
        Narrator.Instance.AnimationBackground(TriggerKey);
    }
    public void OnButtonPress(){
        Narrator.Instance.NextAct();
    }

    public override void OnEnd() {
        Debug.Log("End AnimB Act");
    }
}