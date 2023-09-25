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

    [SerializeField] Image[] images;
    [SerializeField] Image blackBackgroundCook;
    [SerializeField] Image blackBackground;
    [SerializeField] float fadeInTime;
    [SerializeField] float fadeOutTime;

    static public StoryTeller instance;

    [SerializeField] ActMoveEnableButtons moveSpriteAct;
    bool onStory = false;
    bool canGoNext = false;
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

    public void TellStoryMid()
    {
        FadeInStoryMid();
        FadeOutStoryMid();
    }
    public void TellStoryEnd()
    {
        FadeInStoryEnd();
        FadeOutStoryEnd();
    }


    void FadeInStoryCook() //Se llama a esta funcion para que se haga la animacion de FadeIn de estar cocinando
    {
        if (!onStory)
        {
            onStory = true;
            blackBackgroundCook.DOFade(1, 0.3f);
            images[0].DOFade(1f, 0.5f).OnComplete(() =>
            {
                images[1].DOFade(1f, 0.5f).OnComplete(() =>
                {
                    images[2].DOFade(1f, 0.5f).OnComplete(() =>
                    {
                        onStory = false;

                        moveSpriteAct.MoveSpriteUp();
                        Invoke("FadeOutStoryCook", 2f);
                    });
                });
            });
        }

    }

    public void FadeOutStoryCook()
    {
        if (!onStory)
        {
            images[0].DOFade(0, 0.15f);
            images[1].DOFade(0, 0.15f);
            images[2].DOFade(0, 0.15f).OnComplete(() =>
            {
                blackBackgroundCook.DOFade(0, 0f);
                onStory = false;

            });

        }

    }
    void FadeInStoryStart()//Se llama a esta funcion para que se haga la animacion de FadeIn del comienzo
    {
        if (!onStory)
        {
            onStory = true;
            blackBackground.DOFade(1, 0.3f);
            images[3].DOFade(1, 1.5f).OnComplete(() =>
            {
                images[4].DOFade(1, 1.5f).OnComplete(() =>
                {
                    images[5].DOFade(1, 1.5f).OnComplete(() =>
                    {
                        onStory = false;
                        canGoNext = true;

                    });
                });
            });
        }

    }

    public void FadeOutStoryStart()
    {
        if (!onStory)
        {
            canGoNext = false;
            images[3].DOFade(0, 0f);
            images[4].DOFade(0, 0f);
            images[5].DOFade(0, 0f).OnComplete(() =>
            {
                onStory = false;
                blackBackground.DOFade(0, 0f);
                Narrator.Instance.NextAct();
                Debug.Log("1");

            });

        }

    }
    public void FadeInStoryMid()
    {
        if (!onStory)
        {
            onStory = true;
            blackBackground.DOFade(1, 0.3f);
            images[6].DOFade(1, 1.5f).OnComplete(() =>
            {
                images[7].DOFade(1, 1.5f).OnComplete(() =>
                {
                    images[8].DOFade(1, 1.5f).OnComplete(() =>
                    {
                        onStory = false;
                        canGoNext = true;

                    });
                });
            });
        }
    }
    public void FadeOutStoryMid()
    {
        if (!onStory)
        {
            canGoNext = false;
            images[6].DOFade(0, 0f);
            images[7].DOFade(0, 0f);
            images[8].DOFade(0, 0f).OnComplete(() =>
            {
                onStory = false;
                blackBackground.DOFade(0, 0f);
                Narrator.Instance.NextAct();
                Debug.Log("1");

            });

        }
    }
    public void FadeInStoryEnd()
    {
        if (!onStory)
        {
            onStory = true;
            blackBackground.DOFade(1, 0.3f);
            images[9].DOFade(1, 1.5f).OnComplete(() =>
            {
                onStory = false;
                canGoNext = true;

            });
        }
    }
    public void FadeOutStoryEnd()
    {
        if (!onStory)
        {
            canGoNext = false;
            images[9].DOFade(0, 0f).OnComplete(() =>
            {
                onStory = false;
                Narrator.Instance.NextAct();
                Debug.Log("1");

            });

        }
    }
    void Update()
    {
        if (canGoNext)
        {
            FadeOutStoryStart();
        }
    }
}
