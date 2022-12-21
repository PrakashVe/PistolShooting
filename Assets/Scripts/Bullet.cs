using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using projectShoot;
using TMPro; 

public class Bullet : MonoBehaviour
{   
    public float life = 2; // bullet life

    int ScoreValue = 10;
    Text score;

    //Target prefab
    public GameObject TargetPrefab;

    public TextMeshPro ScoreText;


    //public game object for spot
    public GameObject spot;

    void Awake()
    {
        //Destroying bullet after 2 sec
        Destroy(gameObject, life);
        
    }


    void Start()
    {
        score = GetComponent<Text>();
        ScoreText = FindObjectOfType<TextMeshPro>();
        
    }
   
    void OnCollisionEnter (Collision collision)

    {
          //Destroy bullet
        Destroy(this.gameObject);
        //target ring name
        Destroy(collision.gameObject);

        var hitpoint = DataSaving.Instance.hitpoint;

        Debug.Log(collision.GetContact(0));
        Vector3 vec = collision.GetContact(0).point;
        hitpoint.Add(vec);



        //Debug.Log("my list : " + myList);
        //ScoreBoardConsole(a);
        var myList = DataSaving.Instance.myList;
        //adding score in list fuction calling
        string a = collision.gameObject.name.ToString();
        myList.Add(a);
        Debug.Log("Game object presnt now..   :  "+myList.Count);

        foreach (string name in DataSaving.Instance.myList)
        {
            Debug.Log(name);          

        }
        // displayText.text = sb.ToString();


        Debug.Log("You Hit Score : "+  collision.gameObject.name);
        
        //Display in TextMeshPro        
        ScoreText.text = "Attempt : " + myList.Count + " You Hit : "+ collision.gameObject.name;
        //ScoreText.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f); // random color of text mesh pro

        //find entire target and destroy or target clone
        Destroy(GameObject.Find("Target"));
        Destroy(GameObject.Find("Target(Clone)"));
        // Instantiate TargetPrefab at position (-0.4455049, 1.6, 10.36385) and zero rotation.
        Instantiate(TargetPrefab, new Vector3(-0.4455049f, 1.6f, 10.36385f), Quaternion.identity);


        //instantial spot
        Instantiate(spot, this.gameObject.transform.position, Quaternion.identity);
        


    }
   
}
