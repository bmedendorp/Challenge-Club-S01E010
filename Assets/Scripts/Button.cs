using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Action OnButtonStatusChanged;
    private Animator animationController;
    private ColorChanger myColorChanger;
    private BoxCollider2D myCollider;
    private bool isPressed = false;

    private void Awake()
    {
        animationController = GetComponent<Animator>();
        myColorChanger = GetComponent<ColorChanger>();
        myCollider = GetComponent<BoxCollider2D>();

        SetPressed(false);
    }

    public void SetPressed(bool isPressed)
    {
        Vector2 pressedOffset = new Vector2(0f, -0.25f);
        Vector2 pressedSize = new Vector2(0.9f, 0.1f);

        Vector2 unpressedOffset = new Vector2(0f, -0.06f);
        Vector2 unpressedSize = new Vector2(0.9f, .45f);

        if (this.isPressed != isPressed)
        {
            this.isPressed = isPressed;
            animationController.SetBool("isPressed", isPressed);

            // Change collider size to match animation
            if (isPressed)
            {
                myCollider.offset = pressedOffset;
                myCollider.size = pressedSize;
            }
            else
            {
                myCollider.offset = unpressedOffset;
                myCollider.size = unpressedSize;
            }

            OnButtonStatusChanged?.Invoke();
        }
    }

    public bool GetPressed()
    {
        return isPressed;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (isPressed)
        {
            return;
        }

        ColorChanger collisionColorChanger = collision.GetComponent<ColorChanger>();
        if (collisionColorChanger.GetColor() == myColorChanger.GetColor())
        {
            SetPressed(true);
        }
        else
        {
            BlockAnimationController blockAnimationController = collision.GetComponent<BlockAnimationController>();
            blockAnimationController.DoFlash();
        }
    }
}
