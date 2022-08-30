// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public enum SpriteColor {red, blue, yellow, purple, orange, green};

    [SerializeField] private SpriteColor spriteColor = SpriteColor.red;

    private SpriteRenderer mySpriteRenderer;

    void Awake()
    {
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        SetColor(spriteColor);
    }

    public void SetColor(SpriteColor spriteColor)
    {
        this.spriteColor = spriteColor;

        Color color = Color.white;
        switch (spriteColor)
        {
            case SpriteColor.red:
                color = Color.red;
                break;
            case SpriteColor.blue:
                color = Color.blue;
                break;
            case SpriteColor.yellow:
                color = Color.yellow;
                break;
            case SpriteColor.purple:
                color = new Color(1f, 0f, 1f);
                break;
            case SpriteColor.orange:
                color = new Color(1f, 0.33f, 0f);
                break;
            case SpriteColor.green:
                color = Color.green;
                break;
        }

        mySpriteRenderer.color = color;
    }

    public SpriteColor GetColor()
    {
        return spriteColor;
    }

    public static SpriteColor GetRandomSpriteColor()
    {
        SpriteColor[] spriteColors = (SpriteColor[])Enum.GetValues(typeof(SpriteColor));
        return spriteColors[UnityEngine.Random.Range(0, spriteColors.Length)];
    }
}
