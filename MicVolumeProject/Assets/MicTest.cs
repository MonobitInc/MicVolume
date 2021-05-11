using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicTest : MonoBehaviour
{
    // Start is called before the first frame update
    AudioClip clip = null;
    void Start()
    {
        Debug.Log("device0:" + Microphone.devices[0]);
        clip = Microphone.Start(Microphone.devices[0], true, 1, 24000);
        while ((Microphone.GetPosition(Microphone.devices[0])) < 0) {}                
    }

    // Update is called once per frame
    void Update()
    {
        float[] data = new float[clip.samples * clip.channels];
        clip.GetData(data, 0);
        Text t = GameObject.Find("StatusText").GetComponent<Text>();
        int pos = Microphone.GetPosition(Microphone.devices[0]);
        Debug.Log("POS:"+pos);
        int u=240;
        if(pos>=u ) {
            float maxvol=0;
            for(int i=0;i<u;i++) if(data[pos-1-i]>maxvol)maxvol=data[pos-1-i];
            maxvol *= 300;
            string s="Device: "+Microphone.devices[0] + "\n";
            s+= "Volume: " ;
            for(int i=0;i<(int)maxvol;i++) s+= "*";
            t.text = s;
        }
    }
}
