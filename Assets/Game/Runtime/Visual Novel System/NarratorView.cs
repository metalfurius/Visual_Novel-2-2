using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NarratorView : View, INarratorViewDialogueBoxProtocol, INarratorViewSelectionsViewProtocol
{
    // ==================== VARIABLES ===================
    [Header("Narrator View")]
    [SerializeField] private NarratorViewDialogueBox dialogueBox;
    [SerializeField] private CustomButton dialogueBoxSkipButton;
    [SerializeField] private Image background;
    [SerializeField] private Image Char1;
    [SerializeField] private Image Char2;
    [SerializeField] private Image BGChar1;
    [SerializeField] private Image BGChar2;
    [SerializeField] private Image BGChar3;
    [SerializeField] private Image BGChar4;



    [SerializeField] private Animator animBG;
    [SerializeField] private Animator animFade;

    [Header("Selection View")]
    [SerializeField] private NarratorViewSelectionsView selectionsView;

    // ==================== METODOS ====================
    protected override void Initialize()
    {
        base.Initialize();

        dialogueBox.Initialize(this);
        selectionsView.Initialize(this);

        dialogueBoxSkipButton.OnClick.RemoveAllListeners();
        dialogueBoxSkipButton.OnClick.AddListener(DialogueBoxSkipButtonAction);
    }

    public void ShowDialogueBox(NarratorViewDialogueBox.Parameters _parameters)
    {
        Show();

        dialogueBox.Show(_parameters);
        DialogueBoxSkipButtonEnabled();
    }

    public void ChangeBackground(Sprite background)
    {
        Show();
        this.background.sprite = background;
    }
    public void ChangeBGSprites(Sprite one, Sprite two, Sprite three, Sprite four)
    {
        Show();
        // Comprueba si las imágenes son null y establece su alpha en 0 si es necesario
        if (one == null)
        {
            BGChar1.color = new Color(BGChar1.color.r, BGChar1.color.g, BGChar1.color.b, 0f);
        }
        else
        {
            BGChar1.sprite = one;
            BGChar1.color = new Color(BGChar1.color.r, BGChar1.color.g, BGChar1.color.b, 1f);
        }

        if (two == null)
        {
            BGChar2.color = new Color(BGChar2.color.r, BGChar2.color.g, BGChar2.color.b, 0f);
        }
        else
        {
            BGChar2.sprite = two;
            BGChar2.color = new Color(BGChar2.color.r, BGChar2.color.g, BGChar2.color.b, 1f);
        }

        if (three == null)
        {
            BGChar3.color = new Color(BGChar3.color.r, BGChar3.color.g, BGChar3.color.b, 0f);
        }
        else
        {
            BGChar3.sprite = three;
            BGChar3.color = new Color(BGChar3.color.r, BGChar3.color.g, BGChar3.color.b, 1f);
        }

        if (four == null)
        {
            BGChar4.color = new Color(BGChar4.color.r, BGChar4.color.g, BGChar4.color.b, 0f);
        }
        else
        {
            BGChar4.sprite = four;
            BGChar4.color = new Color(BGChar4.color.r, BGChar4.color.g, BGChar4.color.b, 1f);
        }
    }


    public void AnimationBackground(string animation)
    {
        Show();
        DialogueBoxSkipButtonDisabled();
        animBG.SetTrigger(animation);
    }
    public void Fade(string animation)
    {
        Show();
        DialogueBoxSkipButtonDisabled();
        animFade.SetTrigger(animation);

    }
    public void ChangeSprite1(Sprite sprite)
    {
        Show();
        this.Char1.sprite = sprite;
    }

    public void ChangeSprite2(Sprite sprite)
    {
        Show();
        this.Char2.sprite = sprite;
    }

    public void ShowSelectionsView(NarratorViewSelectionsView.Parameters _parameters)
    {
        Show();

        selectionsView.Show(_parameters);
    }

    // =================================================

    private void DialogueBoxSkipButtonAction() { TextTyperSystem.SkipDialogue(); }
    private void DialogueBoxSkipButtonEnabled() { dialogueBoxSkipButton.enabled = true; }
    private void DialogueBoxSkipButtonDisabled() { dialogueBoxSkipButton.enabled = false; }

    // =================================================

    #region INarratorViewDialogueBoxProtocol
    public void OnDialogueFinish()
    {
        DialogueBoxSkipButtonDisabled();
        //Narrator.Instance.EndAwning();
        Narrator.Instance.NextAct();
    }
    #endregion

    #region INarratorViewSelectionsViewProtocol
    public void OnSelectedOption(SceneConfig _scene)
    {
        Narrator.Instance.PlayScene(_scene);
    }
    #endregion
}