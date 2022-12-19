using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using projectShoot;

public class ScoreBoard : MonoBehaviour
{
    //*****************NOT USING****************************
    public TextMeshPro ScoreText;

    public Bullet bulletscript;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText = FindObjectOfType<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {       
        string scorevalue = bulletscript.name.ToString();
        ScoreText.text = scorevalue;

        Debug.Log("Name can i Fetch " + name);
    }
}
