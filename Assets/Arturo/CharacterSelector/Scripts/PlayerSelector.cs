using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class PlayerSelector : MonoBehaviour
{
    public Image[] selectionBoxes;
    public GameObject[] prefabs;
    // Start is called before the first frame update
    void Start()
    {
        foreach(var img in this.selectionBoxes)
        {
            img.gameObject.SetActive(false);
        }
        this.Selec(0);
    }

    public void Selec(int index)
    {
        foreach (var img in this.selectionBoxes)
        {
            img.gameObject.SetActive(false);
        }
        this.selectionBoxes[index].gameObject.SetActive(true);
        PlayerStorage.playerPrefab = this.prefabs[index];
    }
    
}
