using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private ColorChanger myColorChanger;

    private void Awake()
    {
        myColorChanger = GetComponent<ColorChanger>();
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.TryGetComponent<ColorChanger>(out ColorChanger colliderColorChanger))
        {
            colliderColorChanger.SetColor(myColorChanger.GetColor());
        }   
    }
}
