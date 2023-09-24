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

    [SerializeField] float fadeInTime;
    [SerializeField] float fadeOutTime;

    static public StoryTeller instance;
    ButtonHandlerActMoveSpriteDown moveSpriteScript;
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
        moveSpriteScript = FindObjectOfType<ButtonHandlerActMoveSpriteDown>();
    }

    
    public void TellStoryByImages(string storyName)
    {
        SetStoryImages(storyName);

        FadeInStory();
    }

    void SetStoryImages(string storyName)
    {
        foreach (Story story in stories)
        {
            if (story.imageChainName == storyName)
            {
                for (int i = 0; i < story.spriteImages.Length; i++)
                {
                    images[i].sprite = story.spriteImages[i];
                }
            }
        }
    }

    void FadeInStory()
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
    
    public void FadeOutStory()
    {
        if (!onStory)
        {
            foreach (Image image in images)
            {
                image.DOFade(0, 0.75f).OnComplete(() =>
                {
                    onStory = false;
                    moveSpriteScript.MoveSpriteUp();
                });
            }
        }
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TellStoryByImages("Cooking");
        }
       
    }
}
