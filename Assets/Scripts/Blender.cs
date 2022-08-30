using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blender : MonoBehaviour
{
    [SerializeField] Button leftButton;
    [SerializeField] Button rightButton;
    [SerializeField] GameObject blockPrefab;
    [SerializeField] Transform spawnPosition;

    private ColorChanger myColorChanger;

    // Start is called before the first frame update
    private void Start()
    {
        leftButton.OnButtonStatusChanged += Button_OnButtonStatusChanged;
        rightButton.OnButtonStatusChanged += Button_OnButtonStatusChanged;
        myColorChanger = GetComponent<ColorChanger>();
    }

    private void Button_OnButtonStatusChanged()
    {
        Debug.Log("Button Change");
        if (leftButton.GetPressed() && rightButton.GetPressed())
        {
            Debug.Log("Spawning");
            GameObject block = Instantiate(blockPrefab, spawnPosition.position, Quaternion.identity);
            ColorChanger blockColorChanger = block.GetComponent<ColorChanger>();
            blockColorChanger.SetColor(myColorChanger.GetColor());
        }
    }
}
