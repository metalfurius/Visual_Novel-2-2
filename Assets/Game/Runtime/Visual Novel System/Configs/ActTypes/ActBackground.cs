using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Visual Novel/Acts/Background", fileName = "New Act Background")]
public class ActBackground : ActConfig {
    // ==================== VARIABLES ===================
    public Sprite image;

    // ==================== METODOS ====================
    public override void OnStart() {
        Debug.Log("Start Background Act");
        Narrator.Instance.ChangeBackground(image);
        Narrator.Instance.NextAct();
    }

    public override void OnEnd() {
        Debug.Log("End Background Act");
    }
}