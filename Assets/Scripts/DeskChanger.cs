using System.Collections.Generic;
using UnityEngine;

// muss noch getestet und bereinigt werden! 
public class DeskChanger : MonoBehaviour
{
    [SerializeField] private List<GameObject> deskPool = new();
    //[SerializeField] private Transform localPos;
    private int index = 0;

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        ChangeDesk();
    //    }
    //}

    public void ChangeDesk()
    {
        //Indexer erstellt
        int listLenght = deskPool.Count;
        // zweiter Versuche Objekte an- und ausschalten
        deskPool[index].gameObject.SetActive(false);
        #region erster Versuch
        ////alter Tisch wird zerstört
        //Transform child = localPos.GetChild(0);
        //Destroy(child);

        ////neuer Desk wird erstellt und platziert
        //GameObject temp = Instantiate(deskPool[index], localPos.position, Quaternion.identity, localPos);
        #endregion
        //Indexer wird hochgezählt, bzw. zurück gesetzt
        index++;
        if (index >= listLenght)
            index = 0;

        deskPool[index].gameObject.SetActive(true);
        Debug.Log("Test");
    }
}
