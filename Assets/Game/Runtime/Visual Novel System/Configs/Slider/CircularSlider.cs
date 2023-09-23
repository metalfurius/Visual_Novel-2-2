using UnityEngine;

public class CircularSlider : MonoBehaviour {
    public RectTransform Awning;
    public float speed = 50f;
    public float rotationToAwningRatio = 0.001f;

    private Quaternion initialRotation;
    private float lastAwningY;

    private bool finishHandleDrag = false;
    
    [SerializeField] private Animator AwningAnim;

    void Start() {
        initialRotation = transform.rotation;
        lastAwningY = Awning.position.y;
    }

    public void OnHandleDrag() {
        if (Awning.localPosition.y >= 580f && !finishHandleDrag){
            finishHandleDrag = true;

            AwningAnim.SetTrigger("FixAwning");
            //Narrator.Instance.EndAwning();
            Narrator.Instance.NextAct();
            
            return;
        }

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);

        float rotationDelta = transform.rotation.eulerAngles.z - initialRotation.eulerAngles.z;
        float awningDisplacement = rotationDelta * rotationToAwningRatio;
        float newAwningY = lastAwningY + awningDisplacement;

        if (newAwningY > lastAwningY)
        {
            Vector3 awningPosition = Awning.position;
            awningPosition.y = newAwningY;
            Awning.position = awningPosition;
            lastAwningY = newAwningY;
        }

        initialRotation = transform.rotation;
    }
}
