using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[System.Serializable]
public class Story
{
    public string imageChainName;
    public Sprite[] spriteImages;
}

public class StoryTeller : MonoBehaviour
{
    [SerializeField] Story[] stories;

   [SerializeField] SpriteRenderer[] images;

    [SerializeField] float fadeInTime;
    [SerializeField] float fadeOutTime;

    static public StoryTeller instance;

    bool onStory = false;
    private void Awake()
    {
        #region Singleton
        if (!instance) instance = this;
        else Destroy(this);
        #endregion

    }
    void Start()
    {

    }

    
    public void TellStoryCooking()
    {
        FadeInStoryCook();
        FadeOutStoryCook();
    }
    public void TellStoryStart()
    {
        FadeInStoryStart();
        FadeOutStoryStart();
    }

    void FadeInStoryCook() //Se llama a esta funcion para que se haga la animacion de FadeIn de estar cocinando
    {
        if (!onStory)
        {
            onStory = true;

            images[0].DOFade(1, 1.5f).OnComplete(() =>
            {
                images[1].DOFade(1, 1.5f).OnComplete(() =>
                {
                    images[2].DOFade(1, 1.5f).OnComplete(() =>
                    {
                        onStory = false;
                        Invoke("FadeOutStory", 2f);
                    });
                });
            });
        }
       
    }
    
    public void FadeOutStoryCook() 
    {
        if (!onStory)
        {
                images[0].DOFade(0, 0.75f);
                images[1].DOFade(0, 0.75f);
                images[2].DOFade(0, 0.75f).OnComplete(() =>
                {
                    onStory = false;
                    Narrator.Instance.NextAct();
                });
            
        }
        
    }
    void FadeInStoryStart()//Se llama a esta funcion para que se haga la animacion de FadeIn del comienzo
    {
        if (!onStory)
        {
            onStory = true;

            images[3].DOFade(1, 1.5f).OnComplete(() =>
            {
                images[4].DOFade(1, 1.5f).OnComplete(() =>
                {
                    images[5].DOFade(1, 1.5f).OnComplete(() =>
                    {
                        onStory = false;
                        Invoke("FadeOutStoryStart", 2f);
                    });
                });
            });
        }

    }

    public void FadeOutStoryStart()
    {
        if (!onStory)
        {
            images[3].DOFade(0, 0.75f);
            images[4].DOFade(0, 0.75f);
            images[5].DOFade(0, 0.75f).OnComplete(() =>
            {
                onStory = false;
                Narrator.Instance.NextAct();
            });

        }

    }
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space))
        {
            FadeInStoryStart();
        }
    }
}