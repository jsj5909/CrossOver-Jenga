using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInfo
{
    

    public int id;
    public string subject;
    public string grade;
    public int mastery;
    public string domainid;
    public string domain;
    public string cluster;
    public string standardid;
    public string standarddescription;
    

    public void PrintBlock()
    {
         Debug.Log("Grade: " + grade + "Domain: " + domain + " Cluster: " + cluster + " ID: " + id);
        // Debug.Log("subject: " + subject);
        // Debug.Log("Grade: " + grade);
        // Debug.Log("Mastery " + mastery);
       // Debug.Log("Domain Name: " + domain);
       // Debug.Log("Cluster: " + cluster);
    }

}
