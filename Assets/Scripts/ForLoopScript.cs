using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLoopScript : MonoBehaviour {

    // start for loop 
    public void ExecuteLoop()
    {
        Debug.Log(this);

        int x = 0;

        System.Diagnostics.Stopwatch stopWatch = new System.Diagnostics.Stopwatch();
        stopWatch.Start();

        for (int i = 0; i < 500; i++)
        {
            x += i;
            //Debug.Log("Value of x = " + x);
        }

        stopWatch.Stop();
        Debug.Log("Time taken: " + (stopWatch.Elapsed));
    }
}