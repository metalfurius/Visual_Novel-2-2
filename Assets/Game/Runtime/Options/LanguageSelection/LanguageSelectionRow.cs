using System.Collections;
using System.Collections.Generic;
using UnityEngine.Localization;
using UnityEngine;

using TMPro;

public interface ILanguageSelectionRowProtocol {
    void OnSelectLanguageSelectionRow(Locale _locale);
}

public class LanguageSelectionRow : MonoBehaviour {
    // ==================== VARIABLES ===================
    private ILanguageSelectionRowProtocol Delegate;

    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private CustomButton button;

    private Locale locale;
    
    // ==================== METODOS ====================
    public LanguageSelectionRow Initialize(ILanguageSelectionRowProtocol _delegate, Locale _locale) {
        Delegate = _delegate;
        locale = _locale;

        UpdateRow();
        
        button.OnClick.RemoveAllListeners();
        button.OnClick.AddListener(OnSelectLanguageSelectionRow);

        return this;
    }

    private void OnSelectLanguageSelectionRow() {
        Delegate?.OnSelectLanguageSelectionRow(locale);
    }

    private void UpdateRow() {
        label.text = locale.Identifier.CultureInfo.EnglishName;
    }
}