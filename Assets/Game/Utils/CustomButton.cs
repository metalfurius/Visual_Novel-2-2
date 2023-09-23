using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Image))]
public class CustomButton : MonoBehaviour, IPointerClickHandler {
    // ==================== VARIABLES ===================
    [SerializeField] private Image image;
    [Space]
    public UnityEvent OnClick;
    
    // ==================== INICIO ====================
    private void Reset() {
        image = GetComponent<Image>();
        image.color = Color.clear;
        image.raycastTarget = true;
    }

    // ==================== METODOS ====================
    public void OnPointerClick(PointerEventData eventData) {
        OnClick?.Invoke();
    }
}