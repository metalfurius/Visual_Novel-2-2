using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Visual Novel/Acts/Language", fileName = "New Act Language")]
public class ActLanguage : ActConfig {
    // ==================== VARIABLES ===================

    // ==================== METODOS ====================
    public override void OnStart() {
        OptionsView.ShowLanguageSelection?.Invoke();
        LocalizationSystem.OnLanguageSelected += Narrator.Instance.NextAct;
    }

    public override void OnEnd() {
        LocalizationSystem.OnLanguageSelected -= Narrator.Instance.NextAct;
    }
}