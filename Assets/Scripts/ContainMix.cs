using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainMix : MonoBehaviour
{
    //List to store the names of the items
    private List<string> bowlItemNames = new List<string>();
    

    //When a item hits the bowl then add it to the list
    public void OnCollisionEnter2D(Collision2D coll)
    {
        GameObject collidedWith = coll.gameObject;
        //item clones have clone in the name that needs to be removed
        string itemNameZZZ = collidedWith.name.Replace("(Clone)", "").Trim();
        //store the proper name of the item into the bowls list for compare
        bowlItemNames.Add(itemNameZZZ);
        //destroy the item now that we recorded it
        Destroy(collidedWith);
    }

    //clear the list inside the bowl
    public void ClearTheItemsDestroyed()
    {
        bowlItemNames.Clear();
        Debug.Log("Cleared items");
    }

    //recieve the list inside the bowl
    public List<string> GetDestroyedItemNames()
    {
        return bowlItemNames;
    }

    // Print the names of the items that have been destroyed (added to the bowl)
    public void PrintTheItemsDestroyed()
    {
        //is the bowl empty right now?
        if (bowlItemNames.Count == 0)
        {
            Debug.Log("Blank List");
        }
        else
        {
            //tell me whats in the bowl otherwise
            foreach (string itemName in bowlItemNames)
            {
                Debug.Log(itemName);
            }
        }
    }

}// END