using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public abstract class GameActions : MonoBehaviour
{
    public static Action<Transform> OnTargetSelected;
    public static Action<Transform> OnBoneSelected;
    public static Action NoTurn;
}
