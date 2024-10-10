using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : CharacterHealth
{
    override protected void Death(GameObject diedObject, GameObject diedCauser)
    {
        if (diedObject == gameObject)
            Debug.Log("Игрока " + diedObject.name + " убил " + diedCauser.name);
    }
}
