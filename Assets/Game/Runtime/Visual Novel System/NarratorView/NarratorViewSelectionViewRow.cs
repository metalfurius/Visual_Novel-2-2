using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public interface INarratorViewSelectionViewRowProtocol {
    void OnRowSelected(SceneConfig _scene);
}

public class NarratorViewSelectionViewRow : MonoBehaviour {
    // ==================== VARIABLES ===================
    private INarratorViewSelectionViewRowProtocol Delegate;
    
    [SerializeField] private TextMeshProUGUI label;
    [SerializeField] private CustomButton button;

    private SceneConfig scene;
    
    // ==================== METODOS ====================
    public NarratorViewSelectionViewRow Initialize(INarratorViewSelectionViewRowProtocol _delegate, Narrator.Selection _selection) {
        Delegate = _delegate;

        label.text = LocalizationSystem.GetText(_selection.id);
        scene = _selection.scene;

        button.OnClick.RemoveAllListeners();
        button.OnClick.AddListener(OnRowSelected);

        return this;
    }

    private void OnRowSelected() {
        Delegate?.OnRowSelected(scene);
    }
}