using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "Visual Novel/Acts/FadeInStart", fileName = "New Act FadeInStart")]

public class ActFadeInImagesStart : ActConfig
{
    // ==================== VARIABLES ===================

    public string[] textIds;

    // ==================== METODOS ====================
    public override void OnStart()
    {

        StoryTeller.instance.TellStoryStart();

        //Narrator.Instance.ShowDialogueBox(new NarratorViewDialogueBox.Parameters
        //{
        //    textIds = textIds
        //});
    }
}
