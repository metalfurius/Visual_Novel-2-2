using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RedBlueGames.Tools.TextTyper;

public interface INarratorViewDialogueBoxProtocol {
    void OnDialogueFinish();
}

public class NarratorViewDialogueBox : View {
    public struct Parameters {
        public string[] textIds;
    }
    
    // ==================== VARIABLES ===================
    private INarratorViewDialogueBoxProtocol Delegate;

    [Header("Dialogue Box View")]
    [SerializeField] private TextTyper textTyper;
    
    // ==================== METODOS ====================
    public void Initialize(INarratorViewDialogueBoxProtocol _delegate) {
        Delegate = _delegate;
    }

    public void Show(Parameters _parameters) {
        Show();

        TextTyperSystem.SetDialogues(textTyper, _parameters.textIds, FinishDialogue);
        TextTyperSystem.ShowDialogues();
    }

    private void FinishDialogue() {
        Hide();
        Delegate?.OnDialogueFinish();
    }
}