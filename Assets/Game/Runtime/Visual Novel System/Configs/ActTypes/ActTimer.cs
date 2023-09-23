using UnityEngine;

[CreateAssetMenu(menuName = "Visual Novel/Acts/Timer", fileName = "New Act Timer")]
public class ActTimer : ActConfig {
    // ==================== VARIABLES ===================
    public float minTime;
    public float maxTime;

    // ==================== METODOS ====================
    public override void OnStart() {
        Debug.Log("Start Timer Act");
        Narrator.Instance.SetActTimer(Random.Range(minTime, maxTime), NextAct);
    }

    public override void OnEnd() {
        Debug.Log("End Timer Act");
    }
}