using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ErrorHandler
{
    public static void TryError(bool condition, string errorText)
    {
        if (condition) Debug.LogError(errorText);
    }
}
