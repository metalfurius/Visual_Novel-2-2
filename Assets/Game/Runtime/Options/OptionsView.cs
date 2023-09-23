using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization;
using UnityEngine;

public class OptionsView : View, ILanguageSelectionProtocol {
    // ==================== VARIABLES ===================
    #region Actions
    public static Action ShowLanguageSelection;
    #endregion

    [Header("Options View")]
    [SerializeField] private OptionsViewLanguageSelection languageSelection;

    // ==================== INICIO ====================
    protected override void OnEnable() {
        base.OnEnable();

        ShowLanguageSelection += Show_LanguageSelection;
    }

    protected override void OnDisable() {
        base.OnDisable();
        
        ShowLanguageSelection -= Show_LanguageSelection;
    }

    // ==================== METODOS ====================
    protected override void Initialize() {
        base.Initialize();

        languageSelection.Initialize(this);
    }

    private void Show_LanguageSelection() {
        Show();
        languageSelection.Show();
    }

    #region ILanguageSelectionProtocol
    public void OnSelectLanguageSelectionRow(Locale _locale) {
        LocalizationSystem.SetLanguage(_locale);
        Hide();
    }
    #endregion
}