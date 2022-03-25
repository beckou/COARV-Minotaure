using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TExt : MonoBehaviour
{
    int currentPosition = 0;
    float Delay = 0.1f;  // 10 characters per sec.
    string Text = "";
    string[] additionalLines;
    public Text MyText;

    void WriteText(string aText)
    {
        MyText.text = "";
        currentPosition = 0;
        Text = aText;
    }

    void Start()
    {
        //additionalLines = MyText.text.Split();
        foreach (string s in additionalLines)
            Text += "\n" + s;
        while (true)
        {
             if (currentPosition <= Text.Length-1)
                MyText.text += Text[currentPosition++];
            new WaitForSeconds(Delay);
        }
    }
}
