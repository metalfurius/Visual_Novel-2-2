using System;
using UnityEngine;

public class Timer {
    // ==================== VARIABLES ===================
    public float ElapsedTime { get; private set; } = 0f;

    protected float duration = 0f;
    protected bool finished = false;

    protected Action callback;
    
    // ==================== METODOS ====================
    public Timer(float _duration) {
        ElapsedTime = 0f;

        duration = _duration;
        finished = false;

        callback = null;
        Updater.Ticks += Step;
    }

    public Timer(float _duration, Action _callback) {
        ElapsedTime = 0f;

        duration = _duration;
        finished = false;

        callback = _callback;
        Updater.Ticks += Step;
    }

    public void Step() {
        if (finished) return;
        
        if (duration <= ElapsedTime) {
            ElapsedTime = duration;
            finished = true;
            
            callback?.Invoke();
            Updater.Ticks -= Step;

        } else ElapsedTime += Time.deltaTime;
    }
}