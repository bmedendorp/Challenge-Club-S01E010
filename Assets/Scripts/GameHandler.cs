// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    [SerializeField] private BlockMovement[] allPlayerBlocks;
    [SerializeField] private int coinsRequiredToWin;

    private int coinCount;

    private void Start()
    {
        AllPlayerBlocksArrayUpdate();

        Flag.OnAnyFlagObtained += Flag_OnAnyFlagObtained;
        Coin.OnAnyCoinObtained += Coin_OnAnyCoinObtained;
        coinCount = 0;

        UI.Instance.UpdateCoinCount(coinCount);
    }

    private void Update()
    {
        BlockSelection();
    }

    private void Coin_OnAnyCoinObtained()
    {
        coinCount++;
        UI.Instance.UpdateCoinCount(coinCount);
    }

    private void Flag_OnAnyFlagObtained()
    {
        if (CheckWinConditions())
        {
            UI.Instance.ShowWin();
        }
    }

    private bool CheckWinConditions()
    {
        if (coinCount >= coinsRequiredToWin)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void BlockSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ActiveBlockPlusOne();
        }
        if (Input.GetMouseButtonDown(1))
        {
            ActiveBlockMinusOne();
        }
    }

    public void AllPlayerBlocksArrayUpdate()
    {
        allPlayerBlocks = FindObjectsOfType<BlockMovement>();
    }

    public void DestroyedBlockUpdate()
    {
        ActiveBlockPlusOne();
    }

    private void ActiveBlockPlusOne()
    {
        AllPlayerBlocksArrayUpdate();


        for (int i = 0; i < allPlayerBlocks.Length; i++)
        {
            if (allPlayerBlocks[i].GetComponent<BlockMovement>().isActiveBool)
            {
                allPlayerBlocks[i].GetComponent<BlockMovement>().isActiveBool = false;

                if (i < allPlayerBlocks.Length - 1)
                {
                    allPlayerBlocks[i + 1].GetComponent<BlockMovement>().isActiveBool = true;
                    break;

                }
                else
                {
                    allPlayerBlocks[0].GetComponent<BlockMovement>().isActiveBool = true;
                    break;
                }
            }
        }
    }

    private void ActiveBlockMinusOne()
    {
        AllPlayerBlocksArrayUpdate();

        for (int i = 0; i < allPlayerBlocks.Length; i++)
        {
            if (allPlayerBlocks[i].GetComponent<BlockMovement>().isActiveBool)
            {
                allPlayerBlocks[i].GetComponent<BlockMovement>().isActiveBool = false;

                if (i >= 1)
                {
                    allPlayerBlocks[i - 1].GetComponent<BlockMovement>().isActiveBool = true;
                    break;

                }
                else
                {
                    allPlayerBlocks[allPlayerBlocks.Length - 1].GetComponent<BlockMovement>().isActiveBool = true;
                    break;
                }
            }
        }
    }
}
