using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Visual Novel/Acts/Background", fileName = "New Act Background")]
public class ActBackground : ActConfig {
    // ==================== VARIABLES ===================
    public Sprite image;
    public Sprite BGChar1;
    public Sprite BGChar2;
    public Sprite BGChar3;
    public Sprite BGChar4;

    // ==================== METODOS ====================
    public override void OnStart() {
        Debug.Log("Start Background Act");
        Narrator.Instance.ChangeBackground(image);
        Narrator.Instance.ChangeBGSprites(BGChar1,BGChar2,BGChar3,BGChar4);
        Narrator.Instance.NextAct();
    }

    public override void OnEnd() {
        Debug.Log("End Background Act");
    }
}