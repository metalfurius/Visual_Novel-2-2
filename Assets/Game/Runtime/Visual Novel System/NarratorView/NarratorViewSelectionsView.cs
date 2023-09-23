using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INarratorViewSelectionsViewProtocol {
    void OnSelectedOption(SceneConfig _scene);
}

public class NarratorViewSelectionsView : View, INarratorViewSelectionViewRowProtocol {
    public struct Parameters {
        public Narrator.Selection[] selections;
    }
    
    // ==================== VARIABLES ===================
    private INarratorViewSelectionsViewProtocol Delegate;

    [Header("Dialogue Box View")]
    [SerializeField] private NarratorViewSelectionViewRow row;
    [SerializeField] private Transform rowContent;

    private NarratorViewSelectionViewRow[] rows;
    
    // ==================== METODOS ====================
    public void Initialize(INarratorViewSelectionsViewProtocol _delegate) {
        base.Initialize();
        
        Delegate = _delegate;
    }

    public void Show(Parameters _parameters) {
        Show();
        
        InstantiateRows(_parameters);
    }

    private void InstantiateRows(Parameters _parameters) {
        if (rows != null && rows.Length > 0) {
            for (byte i = 0; i < rows.Length; i++) Destroy(rows[i].gameObject);
        }

        rows = new NarratorViewSelectionViewRow[_parameters.selections.Length];
        for (byte i = 0; i < rows.Length; i++) {
            rows[i] = Instantiate(row, rowContent).Initialize(this, _parameters.selections[i]);
        }
    }
    
    #region INarratorViewSelectionViewRowProtocol
    public void OnRowSelected(SceneConfig _scene) {
        Hide();
        Delegate?.OnSelectedOption(_scene);
    }
    #endregion
}