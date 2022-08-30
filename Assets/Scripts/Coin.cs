using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static Action OnAnyCoinObtained;
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
            PickupCoin();
        }
        else
        {
            BlockAnimationController blockAnimationController = collision.GetComponent<BlockAnimationController>();
            blockAnimationController.DoFlash();
        }
    }

    private void PickupCoin()
    {
        this.gameObject.SetActive(false);
        OnAnyCoinObtained?.Invoke();
    }
}
