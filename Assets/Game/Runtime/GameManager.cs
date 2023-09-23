using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    // ==================== VARIABLES ===================
    #region Actions
    public static Action OnStart;
    #endregion
    
    // ==================== INICIO ====================
    private void Start() {
        Initialize();
    }
    
    private void Update() {
        Updater.Ticks?.Invoke();
    }
    
    // ==================== METODOS ====================
    private async void Initialize() {
        await LocalizationSystem.Initialize();

        OnStart?.Invoke();
    }
}