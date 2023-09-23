using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Visual Novel/Scene", fileName = "New Scene")]
public class SceneConfig : ScriptableObject {
    // ==================== VARIABLES ===================
    public ActConfig[] acts;
    
    // ==================== METODOS ====================
    public void Test() {
        acts[0].OnStart();
    }
}