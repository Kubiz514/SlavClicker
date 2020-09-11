using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour
{
    public UnityEngine.UI.Text gpc;
    public UnityEngine.UI.Text goldDisplay;
    public float gold = 0.00f;
    public int goldperclick = 1;
    public GameObject tapGraphics;
    public GameObject canvas;
    public Animator animator;

    void Update()
    {
        goldDisplay.text = "seeds: " + gold.ToString("F0");
        gpc.text = goldperclick + "seed/click";

        //Adds gold and displays +1 after each tap 
        if (Input.touchCount > 0)
        {
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    if (!EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                    {
                        gold += goldperclick;
                        Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
                        Instantiate(tapGraphics, touchPosition, Quaternion.identity, canvas.transform);
                        animator.SetBool("IsEating", true);    
                    }
                }
            }
        }
    }
}