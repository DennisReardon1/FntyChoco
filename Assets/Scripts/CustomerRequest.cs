using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CustomerRequest : MonoBehaviour
{
    public Image customerImage;
    public TextMeshProUGUI customerText;
    //easy to dump them all inside unity this way
    public List<Sprite> customerSprites;
    public List<GameObject> chocolatePrefabs;
    public List<GameObject> prefabItems;
    //lists to check for
    private string requestedChocolate;
    private string requestedItemY;
    private string requestedItemZ;
    //to turn off the customer image initially
    private bool customerActive = false;
    //to create more randomness in the response
    public float TEMPERNUMBER = 0;

    //to make the text writing effect work
    public IEnumerator TypeText(string text)
    {
        customerText.text = "";
        foreach (char letter in text.ToCharArray())
        {
            customerText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    //spawn the customer
    public void SpawnCustomerWithTyping()
    {
        //if theres already a customer stop the bell from working
        if (customerActive)
        {
            return;
        }
        customerActive = true;

        //get a random customer image
        customerImage.sprite = customerSprites[Random.Range(0, 15)];

        //get a random chocolate and 2 random items to mix the chocolate with.
        requestedChocolate = chocolatePrefabs[Random.Range(0, 3)].name;
        requestedItemY = prefabItems[Random.Range(0, 9)].name;
        requestedItemZ = prefabItems[Random.Range(0, 9)].name;

        //what does the customer say, based on the random number rolled
        TEMPERNUMBER = Random.value;
        string customerRequest = "TEMP";
        if (TEMPERNUMBER <= 0.1)
        {
            customerRequest = "Can I get some " + requestedChocolate + ", I want it both " + requestedItemY + " and " + requestedItemZ + ".";
        }
        else if (TEMPERNUMBER <= 0.2)
        {
            customerRequest =  "Fee-fi-fo-fum! Give me a " + requestedItemZ +" "+ requestedItemY +" "+ requestedChocolate + " or ill make you dumb!";
        }
        else if (TEMPERNUMBER <= 0.3)
        {
            customerRequest =  "Human! I demand some " + requestedItemY +" "+ requestedChocolate + "! extra " + requestedItemZ + "!";
        }
        else if (TEMPERNUMBER <= 0.4)
        {
            customerRequest = requestedChocolate + " sounds pretty good right now. can you make it " + requestedItemY + " and " + requestedItemZ + "?"; 
        }
        else if (TEMPERNUMBER <= 0.5)
        {
            customerRequest = "Hey, ever heard of " + requestedItemY + " " + requestedItemZ + " " + requestedChocolate + "? could I have some?"; 
        }
        else if (TEMPERNUMBER <= 0.6)
        {
            customerRequest = requestedItemY +" "+requestedItemY +" "+requestedItemY +" "+requestedChocolate+"! oh, and make it a little "+requestedItemZ +".";
        }
        else if (TEMPERNUMBER <= 0.7)
        {
            customerRequest = "whoops, this isnt the potion shop. well give me a "+requestedItemY+" "+requestedChocolate+", and throw in something "+requestedItemZ+" for taste.";
        }
        else if (TEMPERNUMBER <= 0.8)
        {
            customerRequest = "The stars whisper of something " + requestedItemY + " mixed with something " + requestedItemZ + ". And don't forget the " + requestedChocolate + ".";
        }
        else if (TEMPERNUMBER <= 0.9)
        {
            customerRequest = "I seek a chocolate blend bold and strong, " + requestedChocolate + ", touched with some " + requestedItemY + "  sauce, kissed with " + requestedItemZ + " paste.";
        }
        else
        {
            customerRequest = "Hehehe, surprise me! How about a " + requestedItemY + " filling and " + requestedItemZ + " chunks covered in " + requestedChocolate + " to go!";
        }

        //speak my customer
        StartCoroutine(TypeText(customerRequest));
        customerImage.gameObject.SetActive(true);
        customerText.gameObject.SetActive(true);
    }

    // Get the requested items as a list of strings
    public List<string> GetCustomerRequest()
    {
        return new List<string> { requestedChocolate, requestedItemY, requestedItemZ };
    }

    //clear the customer for a new one
    public void ClearCustomer()
    {
        //the bell will be activated again
        customerActive = false;
        customerImage.gameObject.SetActive(false);
        customerText.gameObject.SetActive(false);
    }

    //double check if a customer is active right now
    public bool IsCustomerActive()
    {
        return customerActive;
    }

}//END