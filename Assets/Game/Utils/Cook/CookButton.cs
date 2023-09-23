using UnityEngine;
using UnityEngine.UI;

public class CookButton : MonoBehaviour
{
    public Button cookButton;

    private void Start()
    {
        cookButton.onClick.AddListener(Cook);
    }

    private void Cook()
    {
        CookingManager.Instance.Cook();
    }
}
