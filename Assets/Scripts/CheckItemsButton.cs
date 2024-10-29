using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckItemsButton : MonoBehaviour
{
    //hook up parts and pieces
    public ContainMix bowl;
    public CustomerRequest customerRequest;
    public GameObject perfectComboImage; 
    public GameObject goodComboImage; 
    public GameObject badComboImage;
    //PCS is for point scoring
    public PCS pcs;

    void Start() {
        //grab the components for keeping score
        GameObject Tally = GameObject.Find( "PCS");
        pcs = Tally.GetComponent<PCS>();
    }
    
    public void CheckItems()
    {
        //make a list of items for the bowl and the customer
        List<string> customerItems = customerRequest.GetCustomerRequest();
        List<string> bowlItems = bowl.GetDestroyedItemNames();

        //compare the items between the two strings
        int correctCount = 0;
        foreach (string customerItem in customerItems)
        {
            if (bowlItems.Contains(customerItem))
            {
                correctCount++;
            }
        }

        //if all items from customer are in the bowl, get a point on score 
        if (correctCount == 3)
        {
            DisplayComboMessage(perfectComboImage);
            pcs.score += 1;
            
            //if you get 5 total perfects then you win!
            if (pcs.score >= 5)
            {
                SceneManager.LoadScene("_Scene_2");
            }
            
        }
        else if (correctCount == 2)
        {
            //i let you continue to play if you got the chocolate and 1 correct item
            DisplayComboMessage(goodComboImage);
        }
        else
        {
            //if you get nothing right your sent to the game over screen
            UnityEngine.SceneManagement.SceneManager.LoadScene("_Scene_3");
            DisplayComboMessage(badComboImage);
        }

        //after anything clear the bowl list and customer list for the next customer
        bowl.ClearTheItemsDestroyed();
        customerRequest.ClearCustomer();
    }

    
    private void DisplayComboMessage(GameObject messageImage)
{
    //spawn whichever comboimage
    GameObject message = Instantiate(messageImage);
    RectTransform rectTransform = message.GetComponent<RectTransform>();
    //kill the message after a second
    Destroy(message, 1f);
}

}//END