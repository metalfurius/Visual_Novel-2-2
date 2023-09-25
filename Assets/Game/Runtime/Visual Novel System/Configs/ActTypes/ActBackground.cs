using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Visual Novel/Acts/Background", fileName = "New Act Background")]
public class ActBackground : ActConfig {
    // ==================== VARIABLES ===================
    public Sprite image;
    public bool showBGChar1;
    public bool showBGChar2;
    public bool showBGChar3;
    public bool showBGChar4;

    // ==================== METODOS ====================
    public override void OnStart() {
        Debug.Log("Start Background Act");
        Narrator.Instance.ChangeBackground(image);
        Narrator.Instance.ChangeBGSprites(showBGChar1,showBGChar2,showBGChar3,showBGChar4);
        Narrator.Instance.NextAct();
    }

    public override void OnEnd() {
        Debug.Log("End Background Act");
    }
}