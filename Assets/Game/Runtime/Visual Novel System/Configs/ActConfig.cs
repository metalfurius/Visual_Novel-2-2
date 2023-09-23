using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActConfig : ScriptableObject {
    // ==================== VARIABLES ===================
    public bool FadeAtStart;
    public bool FadeAtEnd;
    
    // ==================== METODOS ====================
    public virtual void OnStart() {}
    public virtual void OnEnd() {}

    public void NextAct() { Narrator.Instance.NextAct(); }
}