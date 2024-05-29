using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinMaxFinder
{
    public int FindMin(int[] array)
    {
        int min = array[0];
        for(int i = 0; i < array.Length; i++)
        {
            if (min > array[i]) min = array[i];
        }
        return min;
    }
}
