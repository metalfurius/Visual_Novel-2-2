using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Visual Novel/Acts/Dialogue", fileName = "New Act Dialogue")]
public class ActDialogue : ActConfig {
    // ==================== VARIABLES ===================
    public string[] textIds;
    public Sprite image;
    public bool Awning;

    public Sprite Character1;
    public Sprite Character2;

    // ==================== METODOS ====================
    public override void OnStart() {
        Debug.Log("Start Background");
        Narrator.Instance.ChangeBackground(image);
        if (Awning){    
        Debug.Log("Start Toldo");
        Narrator.Instance.StartAwning();
        }
        if(Character1!=null){
        Narrator.Instance.StartCharacter1(Character1);
        }
        if(Character2!=null){
        Narrator.Instance.StartCharacter2(Character2);
        }
        Debug.Log("Start Dialogue Act");
        Narrator.Instance.ShowDialogueBox(new NarratorViewDialogueBox.Parameters {
            textIds = textIds
        });
    }

    public override void OnEnd() {
        Debug.Log("End Dialogue Act");
        Debug.Log("End Background");
    }
}