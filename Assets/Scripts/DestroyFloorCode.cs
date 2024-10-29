using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFloorCode : MonoBehaviour
{
    //just in case a chocolate or an item falls off the screen we can destroy it   
    void OnCollisionEnter2D(Collision2D  coll)
    {
        GameObject collidedWith = coll.gameObject;
        Destroy( collidedWith );
    }
}//END
