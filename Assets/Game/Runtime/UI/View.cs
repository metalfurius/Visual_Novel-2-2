using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class View : MonoBehaviour {
    // ==================== VARIABLES ===================
    [SerializeField] protected bool visibleOnStart;
    [SerializeField] protected CanvasGroup canvasGroup;
    
    // ==================== INICIO ====================
    protected virtual void OnEnable() {
        GameManager.OnStart += Initialize;
    }
    
    protected virtual void OnDisable() {
        GameManager.OnStart -= Initialize;
    }

    protected void Awake() {
        if (!canvasGroup) canvasGroup = GetComponent<CanvasGroup>();
        if (visibleOnStart) Show(); else Hide();
    }
    
    // ==================== METODOS ====================
    protected virtual void Initialize() {}

    public virtual void Show() {
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;
    }

    public virtual void Hide() {
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;
    }
}
