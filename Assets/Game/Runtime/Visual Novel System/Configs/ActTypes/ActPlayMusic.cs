using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Visual Novel/Acts/Play Music", fileName = "New Act Play Music")]
public class ActPlayMusic : ActConfig {
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
                // Ahora tienes acceso al AudioSource y puedes reproducir el audio.
                // Carga el clip de la carpeta de recursos y reprodúcelo.
                AudioClip musicClip = Resources.Load<AudioClip>("Music/" + clip);
                if (musicClip != null)
                {
                    audioSource.clip = musicClip;
                    audioSource.Play();
                    Narrator.Instance.NextAct();
                }
            }
        }
    }  
    public override void OnEnd() {
        
    }
    }