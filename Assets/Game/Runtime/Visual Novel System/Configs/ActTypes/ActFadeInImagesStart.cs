using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "Visual Novel/Acts/FadeInStart", fileName = "New Act FadeInStart")]

public class ActFadeInImagesStart : ActConfig
{
    // ==================== VARIABLES ===================

    public int Numero=0;

    // ==================== METODOS ====================
    public override void OnStart()
    {
        switch(Numero)
        {
            case 0:
                StoryTeller.instance.TellStoryStart();
            break;
            case 1:
                StoryTeller.instance.TellStoryMid();
            break;
            case 2:
                StoryTeller.instance.TellStoryEnd();
            break;
            default:
            break;
        }

        //Narrator.Instance.ShowDialogueBox(new NarratorViewDialogueBox.Parameters
        //{
        //    textIds = textIds
        //});
    }
}
