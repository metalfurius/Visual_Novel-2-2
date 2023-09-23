using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class LocalizationSystem {
    // ==================== VARIABLES ===================
    #region Actions
    public static Action OnLanguageSelected;
    #endregion
    
    #region Funcs
    public static Func<Locale[]> LocalizationLocales;
    #endregion

    private static AsyncOperationHandle selectedLocaleHandle;
    private static StringTable table;

    // ==================== METODOS ====================
    public static async Task Initialize() {
        selectedLocaleHandle = LocalizationSettings.SelectedLocaleAsync;
        await selectedLocaleHandle.Task;
        if (selectedLocaleHandle.IsDone) Debug.Log("Finished loading localization!");

        LocalizationLocales = LocalizationSettings.AvailableLocales.Locales.ToArray;
    }

    public static void SetLanguage(Locale _locale) {
        LocalizationSettings.SelectedLocale = _locale;
        Debug.Log("Language changed to " + _locale.Identifier.CultureInfo.EnglishName);

        OnLanguageSelected?.Invoke();
    }

    public static string GetText(string _id) {
        table = LocalizationSettings.StringDatabase.GetTable("Test Table");
        return table.GetEntry(_id).LocalizedValue;
    }

    public static string GetText(string _table, string _id) {
        table = LocalizationSettings.StringDatabase.GetTable(_table);
        return table.GetEntry(_id).LocalizedValue;
    }
}