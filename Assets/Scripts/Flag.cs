using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public static Action OnAnyFlagObtained;

    private ColorChanger myColorChanger;

    private void Update()
    {
        myColorChanger = GetComponent<ColorChanger>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        ColorChanger collisionColorChanger = collision.GetComponent<ColorChanger>();
        if (collisionColorChanger.GetColor() == myColorChanger.GetColor())
        {
            OnAnyFlagObtained?.Invoke();
        }
        else
        {
            BlockAnimationController blockAnimationController = collision.GetComponent<BlockAnimationController>();
            blockAnimationController.DoFlash();
        }
    }
}
