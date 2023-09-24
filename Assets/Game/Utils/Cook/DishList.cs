using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DishListUI : MonoBehaviour
{

    [SerializeField] float xMove;
    [SerializeField] float displayTime;
    [SerializeField] GameObject list;
    bool displayed = false;
    bool canWork = true;
    void Start()
    {
        
    }

    public void DisplayRecipes()
    {
        if (canWork)
        {
            if (!displayed)
            {
                StartCoroutine(Cooldown());
                list.transform.DOMoveX(list.transform.position.x + xMove, displayTime);
                displayed = true;
            }
            else
            {
                StartCoroutine(Cooldown());
                list.transform.DOMoveX(list.transform.position.x - xMove, displayTime);
                displayed = false;
            }
        }
        
    }

    IEnumerator Cooldown()
    {
        canWork = false;

        yield return new WaitForSeconds(displayTime);
        canWork = true;
    }
    void Update()
    {
        
    }
}
