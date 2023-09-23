using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Visual Novel/Acts/Awning", fileName = "New Act Awning")]
public class ActAwning : ActConfig {
    // ==================== VARIABLES ===================
    public Sprite image;
    public bool Awning;

    // ==================== METODOS ====================
    public override void OnStart() {
        Debug.Log("Start Background");
        Narrator.Instance.ChangeBackground(image);
        
        if (Awning) {    
            Debug.Log("Start Toldo");
            Narrator.Instance.StartAwning();
        }
    }

    public override void OnEnd() {
        Debug.Log("End Toldo Act");
        Debug.Log("End Background");
    }
}