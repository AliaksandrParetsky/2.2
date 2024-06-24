
using UnityEngine;

public class FirstMate : Mate
{
    private void Start()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }
}
