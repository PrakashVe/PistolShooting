using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

namespace projectShoot{
    public class Gun : MonoBehaviour
    {
        // for trigger  
        public SteamVR_Action_Boolean m_GrabAction = null;
        private SteamVR_Behaviour_Pose m_Pose = null;
        private FixedJoint m_Joint = null;
  

        // for bullet
        public Transform bulletspawnpoint;
        public GameObject bulletprefab;
        public float bulletSpeed = 10;

        // for audio
        public AudioSource source;
        public AudioClip clip;

        //for target to count
        public string TargetTag = "Target";

        public bool triggerwaiting;  // bool fuction to wait for trigger pressed
        // Start is called before the first frame update
        private void Awake()
        {
            m_Pose = GetComponent<SteamVR_Behaviour_Pose>();
            m_Joint = GetComponent<FixedJoint>();
            triggerwaiting = false;
        }

        // Update is called once per frame
        private void Update()
        {
            /* Bullet shoot when space key is pressed
            if (Input.GetKeyDown(KeyCode.Space))    
            {
                var bullet = Instantiate(bulletprefab, bulletspawnpoint.position, bulletspawnpoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletspawnpoint.forward * bulletSpeed;
            }
            */

            if (triggerwaiting == false) // check whether trigger pressed in last 3 sec
            { 
            //Trigger pressed
               if (m_GrabAction.GetStateDown(m_Pose.inputSource))
               {
                  //* Bullet shoot when trigger is pressed
                var bullet = Instantiate(bulletprefab, bulletspawnpoint.position, bulletspawnpoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletspawnpoint.forward * bulletSpeed;
                Debug.Log("Trigger is pressed");

                //Gunshot sound
                GunshotSound();


                //Target count if more than 1 then delete 
                GameObject[] Targetclone = GameObject.FindGameObjectsWithTag(TargetTag);
                int TargetcloneCount = Targetclone.Length;
                Debug.Log("Number of TargetClone: " + TargetcloneCount);
                   if(TargetcloneCount>1)
                 {                                        
                    Destroy(GameObject.Find("Target(Clone)"));
                 }

                triggerwaiting = true;  // enabling trigger waiting time 
                StartCoroutine(WaitAndPrint(1.0f)); // waiting time for 3 sec
                }

                void GunshotSound()
                {
                    source.PlayOneShot(clip);
                }           
            }
        }


        //trigger pressed will work after 3 sec every time it pressed
        IEnumerator WaitAndPrint(float waitTime)
        {
            yield return new WaitForSeconds(waitTime);
            triggerwaiting = false;  // Disabling trigger waiting time
            //Debug.Log("Waited for " + waitTime + " seconds");
            
            
            Destroy(GameObject.Find("Spot(Clone)"));// destroy spot 

        }

    }
}

