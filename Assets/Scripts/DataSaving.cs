using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace projectShoot
{
    public class DataSaving : MonoBehaviour
    {
        public static DataSaving Instance { get; private set; }

        //list to store score
        public List<string> myList = new List<string>();
        public List<string> Score = new List<string>();
        public List<Vector3> hitpoint = new List<Vector3>();


        //Hit prefab
        public GameObject HitSpot;
        public string HitSpotTag = "HitSpot";

        private void Awake()
        {
            // If there is an instance, and it's not me, delete myself.

            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
                Debug.Log("  :    Instance :  ");               
            }
        }

        //save
        private void OnDestroy()
        {
            string time = System.DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            // Desktop location
            string name = $"C:\\Users\\Prakash\\Desktop\\Hari\\10mShooting-{time}.txt";

            Debug.Log("Name name " + name);
            int i = 0;
            foreach(var s in myList)
            {
                var pointx = hitpoint[i].x;
                var pointy = hitpoint[i].y;
                var pointz = hitpoint[i].z;
                File.AppendAllText(name, s);
                var val = string.Format(";x-{0};y-{1};z-{2}",pointx,pointy,pointz);
                File.AppendAllText(name, val);
                File.AppendAllText(name, "\n");
                i++;                               
            }
            
        }

        /*
        void Update()
        {
            Destroy(GameObject.Find("HitSpot(Clone)"),1 );
            int i = 0;
            foreach (var s in myList)
            {
                if(GameObject.Find("Bullet(Clone)"))
                {
                    Destroy(GameObject.Find("HitSpot(Clone)"));
                }
                var pointx = hitpoint[i].x;
                var pointy = hitpoint[i].y;
                var pointz = hitpoint[i].z;

                //HitSpot count Generate only 1
                GameObject[] HitSpotclone = GameObject.FindGameObjectsWithTag(HitSpotTag);
                int HitSpotcloneCount = HitSpotclone.Length;               
                if (HitSpotcloneCount < 1)
                {
                    Instantiate(HitSpot, new Vector3(pointx, pointy, pointz), Quaternion.identity);
                }               
                i++;
                
            }          

        }
        */
    }
}