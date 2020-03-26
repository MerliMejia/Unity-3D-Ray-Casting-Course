using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun
{
    public GunTypes type;
    public override float aimingThickness
    {
        get { return type.aimingThickness; }
    }
}
