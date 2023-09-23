using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Visual Novel/Acts/Stop Music", fileName = "New Act Stop Music")]
public class ActStopMusic : ActConfig {
    // ==================== VARIABLES ===================
    public string container = "";
    public string clip = "";
     // ==================== METODOS ====================
    public override void OnStart()
    {
    GameObject containerObject = GameObject.Find(container);
    if (containerObject != null)
    {
        AudioSource audioSource = containerObject.GetComponent<AudioSource>();
        if (audioSource != null)
        {
            // Detener la reproducción de audio.
            audioSource.Stop();
            Narrator.Instance.NextAct();
        }
    }
    }
      public override void OnEnd() {
        
    }
}