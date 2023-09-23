using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Visual Novel/Acts/Selections", fileName = "New Act Selections")]
public class ActSelections : ActConfig {
    // ==================== VARIABLES ===================
    public Narrator.Selection[] selections;

    // ==================== METODOS ====================
    public override void OnStart() {
        Narrator.Instance.ShowSelectionsView(new NarratorViewSelectionsView.Parameters{
            selections = selections
        });
    }

    public override void OnEnd() {
        
    }
}