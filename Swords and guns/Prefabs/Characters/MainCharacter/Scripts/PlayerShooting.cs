using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : Shooting
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GunShot();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            GunReload();
        }
        GunCursorTracking();
    }
}
