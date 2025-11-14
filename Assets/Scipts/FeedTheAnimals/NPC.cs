using System;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class NPC : MonoBehaviour

{

    [SerializeField] GameObject foodItEats;
    [SerializeField] float animalSpeed;
    private float lowerBound;
    private bool isOutOfScene;
    private bool notHungry;
    private float centerToEdge;
    private float playerSpeed = 5;
   
   
   
    void Start()
    {
        lowerBound = -17;
    }

    void Update()
    {
        MoveForward();
    }

    void MoveForward()
    {
        transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        
    }

    void DeleteOutOfScene()
    {

    }

    bool IsFoodItEats()
    {
        return false;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Food") && !notHungry)
        {
            if (IsFoodItEats(other.name))
            {
                Scoreboard.Instance.UpdateScore(10);
            }
            else
            {
                Scoreboard.Instance.UpdateScore(-1);

            }

        }
    
    
    
    }

    private bool IsFoodItEats(string foodTriggered)
    {
        string foodItEatsName = foodItEats.name;

        // Remove "(Clone)" if it exists
        int cloneIndex = foodTriggered.IndexOf("(Clone)");
        if (cloneIndex != -1)
        {
          foodTriggered = foodTriggered.Substring(0, cloneIndex).Trim();
      }
      // Compare the cleaned names
      return foodTriggered.Equals(foodItEatsName);
   }

    








}
