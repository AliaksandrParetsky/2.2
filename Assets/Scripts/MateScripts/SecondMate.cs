
using UnityEngine;

public class SecondMate : Mate
{

    private void Start()
    {
        GetComponent<Renderer>().material.color = Color.blue;
    }
}
