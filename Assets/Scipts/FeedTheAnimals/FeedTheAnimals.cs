/******************************************************************************  
 * Class: FeedTheAnimals
 * Purpose: Controls player movement based on input.  
 * Component Of: Player GameObject  
 * Fields: 
 *   - Food (float) 
 * Behaviors:
 *   - OnFeedAnimalEnter
 *   - FeedAnimal
 * Author: Zo Nijjar
 * Version: August, 2025 v. 1.0
 *******************************************************************************/

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class FeedTheAnimals : MonoBehaviour
{
    [SerializeField] private GameObject[] foods;
    [SerializeField] private float maxForce;
    [SerializeField] private AudioSource audioSource;

    //public fields


    private void FeedAnimal(int index, int foodCount, bool allFood)
    {
        Vector3 position = transform.position + new Vector3(0, 2, 0);

        audioSource.Play();
        for (int i = 0; i < foodCount; i++)
        {
            GameObject foodsInstance = Instantiate(foods[index], position, Quaternion.identity);
            Rigidbody foodsRB = foodsInstance.GetComponent<Rigidbody>();

            if (foodsRB != null)
            {
                float magnitude = maxForce * Random.Range(0.6f, 1f);
                float xDirection = Random.Range(-0.1f, 0.1f);
                foodsRB.AddForce(new Vector3(xDirection, 0, 1) * magnitude, ForceMode.Impulse);
            }
        }


        if (allFood)
        {
            //loop thru all food prefabs
            foreach (GameObject foodPrefab in foods)
            {
                GameObject foodInstance = Instantiate(foodPrefab, position, Quaternion.identity);
                Rigidbody foodRB = foodInstance.GetComponent<Rigidbody>();
                foodRB.AddForce(Vector3.forward * maxForce, ForceMode.Impulse);

            }
        }




    }
    public void OnFeedInput(InputAction.CallbackContext ctx)
    {
        //Only feeds animals on start press.  Ignores ctx.proceed and ctx.cancel.
        if (ctx.started)
        {
            //Send name of button pressed to FeedAnimal
            SelectFood(ctx.control.name);

        }
    }


    
    
    private void SelectFood(string keyName)
    {
        Debug.Log($"Keyname: {keyName}");
        switch (keyName)
        {
            case "z":
                FeedAnimal(0, 3, false);
                break;

            case "x":
                FeedAnimal(1, 3, false);
                break;

            case "c":
                FeedAnimal(2, 3, false);
                break;
            case "space":
                FeedAnimal(3, 99, true);
                break;


        }




    }








}
