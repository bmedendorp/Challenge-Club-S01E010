// GameDev.tv ChallengeClub.Got questionsor wantto shareyour niftysolution?
// Head over to - http://community.gamedev.tv

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNewBlock : MonoBehaviour
{
    [SerializeField] GameObject blockPrefab;
    [SerializeField] Transform spawnPosition;

    public void SpawnBlock()
    {
        GameObject block = Instantiate(blockPrefab, spawnPosition.position, Quaternion.identity);
        ColorChanger blockColorChanger = block.GetComponent<ColorChanger>();
        blockColorChanger.SetColor(ColorChanger.GetRandomSpriteColor());
    }
}
