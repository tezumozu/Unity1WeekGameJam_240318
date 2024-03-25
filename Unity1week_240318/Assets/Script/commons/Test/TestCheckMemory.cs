using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCheckMemory : MonoBehaviour
{
    [SerializeField]
    GameObject textObject;

    Text SystemText;

    void Start(){
        if(textObject is null) Debug.Log(true);
        SystemText = textObject.GetComponent<Text>();
    }


    // Update is called once per frame
    void Update(){
        
        float fps = 1.0f / Time.deltaTime;
        float mem = (UnityEngine.Profiling.Profiler.GetTotalAllocatedMemoryLong() >> 10) / 1024f;
        float unused = (UnityEngine.Profiling.Profiler.GetTotalUnusedReservedMemoryLong() >> 10) / 1024f;
        
        SystemText.text = fps.ToString("0.00") + " FPS\nMemory: " + mem + " / " + unused;
    }
}
