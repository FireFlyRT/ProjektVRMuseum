using System.Collections.Generic;
using UnityEngine;

public class ObjectChanger : MonoBehaviour
{
    [SerializeField] private List<GameObject> objPool = new();
    private int index = 0;

    public void ChangeObject()
    {
        //Indexer erstellt
        int listLenght = objPool.Count;
        objPool[index].gameObject.SetActive(false);
       
        //Indexer wird hochgezählt, bzw. zurück gesetzt
        index++;
        if (index >= listLenght)
            index = 0;

        objPool[index].gameObject.SetActive(true);
        Debug.Log("Test: Hingtergrund");
    }

    public void ObjectSetOff()
    {
        if (objPool[index].gameObject.activeInHierarchy)
            objPool[index].gameObject.SetActive(false);
        else
            objPool[index].gameObject.SetActive(true);
    }
}
