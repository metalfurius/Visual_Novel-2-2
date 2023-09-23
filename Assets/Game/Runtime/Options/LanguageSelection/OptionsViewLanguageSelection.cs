using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization;
using UnityEngine;

public interface ILanguageSelectionProtocol {
    void OnSelectLanguageSelectionRow(Locale _locale);
}

public class OptionsViewLanguageSelection : View, ILanguageSelectionRowProtocol {
    // ==================== VARIABLES ===================
    private ILanguageSelectionProtocol Delegate;
    
    [SerializeField] private LanguageSelectionRow rowPrefab;
    [SerializeField] private Transform rowContent;

    private Dictionary<Locale, LanguageSelectionRow> rows;
    
    // ==================== METODOS ====================
    public void Initialize(ILanguageSelectionProtocol _delegate) {
        Delegate = _delegate;
        
        Locale[] _locales = LocalizationSystem.LocalizationLocales();
        rows = new Dictionary<Locale, LanguageSelectionRow>();

        for (int i = 0; i < _locales.Length; i++) {
            rows.Add(_locales[i], Instantiate(rowPrefab, rowContent).Initialize(this, _locales[i]));
        }
    }

    #region ILanguageSelectionRowProtocol
    public void OnSelectLanguageSelectionRow(Locale _locale) {
        Delegate?.OnSelectLanguageSelectionRow(_locale);
    }
    #endregion
}