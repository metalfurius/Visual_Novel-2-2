using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneData {
    // ==================== VARIABLES ===================
    public ActConfig[] acts;
    public int index = 0;
    
    // ==================== METODOS ====================
    public SceneData(SceneConfig _config) {
        acts = _config.acts;
        index = 0;
    }

    public void StartFirstAct() {
        acts[0].OnStart();
    }

    public void NextAct() {
        if (index >= acts.Length) return;
        acts[index].OnEnd();

        index++;

        if (index >= acts.Length) Debug.Log("= Finished Scene =");
        else acts[index].OnStart();
    }
}