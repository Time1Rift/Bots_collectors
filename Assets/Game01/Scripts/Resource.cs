using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : MonoBehaviour
{
    public bool IsReserved { get; private set; } = false;

    public void Reserve() => IsReserved = true;
}