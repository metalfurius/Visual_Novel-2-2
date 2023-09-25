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
    [SerializeField] private Animator animFadeIn;
    [SerializeField] private Animator animFadeOut;

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
    public void ChangeBGSprites(bool showOne, bool showTwo, bool showThree, bool showFour)
    {
        Show();

        // Activa o desactiva las imágenes en función de las variables booleanas
        BGChar1.gameObject.SetActive(showOne);
        BGChar2.gameObject.SetActive(showTwo);
        BGChar3.gameObject.SetActive(showThree);
        BGChar4.gameObject.SetActive(showFour);
    }



    public void AnimationBackground(string animation)
    {
        Show();
        DialogueBoxSkipButtonDisabled();
        animBG.SetTrigger(animation);
    }
    public void FadeIn(string animation)
    {
        Show();
        DialogueBoxSkipButtonDisabled();
        animFadeIn.SetTrigger(animation);

    }

    public void FadeOut(string animation)
    {
        Show();
        DialogueBoxSkipButtonDisabled();
        animFadeOut.SetTrigger(animation);

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