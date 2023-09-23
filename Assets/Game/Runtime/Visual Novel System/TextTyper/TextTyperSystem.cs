using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RedBlueGames.Tools.TextTyper;

public static class TextTyperSystem {
    // ==================== VARIABLES ===================
    private static Action OnFinish;
    
    private static Queue<string> dialogueLines = new Queue<string>();
    private static TextTyper textTyper;

    // ==================== METODOS ====================
    public static void SetDialogues(TextTyper _textTyper, string[] _ids, Action _OnFinish) {
        textTyper = _textTyper;
        dialogueLines = new Queue<string>();
        OnFinish = _OnFinish;

        for (int i = 0; i < _ids.Length; i++) {
            dialogueLines.Enqueue(_ids[i]);
        }
    }

    public static void ShowDialogues() {
        if (dialogueLines.Count > 0) textTyper.TypeText(LocalizationSystem.GetText(dialogueLines.Dequeue()));
        else OnFinish?.Invoke();
    }

    public static void SkipDialogue() {
        if (textTyper.IsSkippable() && textTyper.IsTyping) textTyper.Skip();
        else ShowDialogues();
    }
}