using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Narrator : Singleton<Narrator> {    
    [Serializable]
    public struct Selection {
        public string id;
        public SceneConfig scene;
    }
    
    // ==================== VARIABLES ===================
    public SceneConfig firstScene;
    public NarratorView view;
    
    [SerializeField] private Animator BGanim;
    [SerializeField] private Animator AwningAnim;
    [SerializeField] private Animator CharAnim;

    private SceneData currentScene;
    private Timer actTimer;
    public bool isActMoveSpriteDownActive = false;

    public ActMoveSpriteDown moveSpriteAct; // Asigna el Scriptable Object en el Inspector.
    public GameObject spriteGameObject; // Asigna el GameObject de la escena en el Inspector.
    
    // ==================== INICIO ====================
    private void OnEnable() {
        GameManager.OnStart += StartFirstScene;
    }

    private void OnDisable() {
        GameManager.OnStart -= StartFirstScene;
    }
    
    // ==================== METODOS ====================
    #region Scenes
    public void StartFirstScene() {
        actTimer = null;

        currentScene = new SceneData(firstScene);
        currentScene.StartFirstAct();
            isActMoveSpriteDownActive = false; // Inicializa la variable en falso al comenzar una nueva escena.

    }
    

    public void PlayScene(SceneConfig _scene) {
        actTimer = null;

        currentScene = new SceneData(_scene);
        currentScene.StartFirstAct();
            isActMoveSpriteDownActive = false; // Inicializa la variable en falso al comenzar un nuevo acto.

    }
    #endregion

    #region Acts    
    public void NextAct() {
        currentScene.NextAct();
    }
    
    public void NextActButton() {
        currentScene.NextAct();
        BGanim.SetTrigger("StopPlay");
    }

    public void SetActTimer(float _time, Action _callback) {
        actTimer = new Timer(_time, OnFinish);

        void OnFinish() {
            _callback?.Invoke();
            actTimer = null;
        }
    }
    #endregion

    #region View
    public void ShowDialogueBox(NarratorViewDialogueBox.Parameters _parameters) {
        view.ShowDialogueBox(_parameters);
    }
    public void ChangeBackground(Sprite background)
    {
        view.ChangeBackground(background);
    }
    public void AnimationBackground(string animation)
    {
        view.AnimationBackground(animation);
    }

    public void StartAwning(){
        AwningAnim.SetTrigger("AppearAwning");
    }
    public void EndAwning(){
        AwningAnim.SetTrigger("IdleAwning");
    }
    public void StartCharacter1(Sprite sprite){
        view.ChangeSprite1(sprite);
        //CharAnim.SetTrigger("Char1Appear");
    }
    public void StartCharacter2(Sprite sprite){
        view.ChangeSprite2(sprite);
        //CharAnim.SetTrigger("Char2Appear");
    }

    public void ShowSelectionsView(NarratorViewSelectionsView.Parameters _parameters) {
        view.ShowSelectionsView(_parameters);
    }
    #endregion
}