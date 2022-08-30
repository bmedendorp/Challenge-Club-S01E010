// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    private GameHandler gameHandler;
    private ColorChanger myColorChanger;

    private void Awake()
    {
        myColorChanger = GetComponent<ColorChanger>();
    }

    private void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            ColorChanger collisionColorChanger = collision.GetComponent<ColorChanger>();
            if (collisionColorChanger.GetColor() == myColorChanger.GetColor())
            {
                return;
            }

            if (collision.gameObject.GetComponent<BlockMovement>().isActiveBool)
            {
                Destroy(collision.gameObject);
                gameHandler.AllPlayerBlocksArrayUpdate();
                gameHandler.DestroyedBlockUpdate();
            }
            else
            {
                Destroy(collision.gameObject);
            }
        }
    }
}
