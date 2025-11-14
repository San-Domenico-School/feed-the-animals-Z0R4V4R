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
    [SerializeField] private float tapThreshold = 0.2f; // Time threshold to distinguish tap from hold
    
    private PlayerMovementController playerMovement;
    private bool isHoldingZ = false;
    private float zKeyPressTime = 0f;

    private void Start()
    {
        // Get reference to PlayerMovementController on the same GameObject
        playerMovement = GetComponent<PlayerMovementController>();
        
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovementController not found on " + gameObject.name);
        }
    }

    private void Update()
    {
        // If Z is being held, apply speed boost
        if (isHoldingZ && playerMovement != null)
        {
            playerMovement.SetSpeedMultiplier(2.0f);
        }
    }

    private void FeedAnimal(int index, int foodCount, bool allFood)
    {
        Vector3 position = transform.position + new Vector3(0, 2, 0);

        audioSource.Play();

        if (allFood)
        {
            // Spawn all food types
            foreach (GameObject foodPrefab in foods)
            {
                GameObject foodInstance = Instantiate(foodPrefab, position, Quaternion.identity);
                Rigidbody foodRB = foodInstance.GetComponent<Rigidbody>();
                if (foodRB != null)
                {
                    float magnitude = maxForce * Random.Range(0.6f, 1f);
                    float xDirection = Random.Range(-0.1f, 0.1f);
                    foodRB.AddForce(new Vector3(xDirection, 0, 1) * magnitude, ForceMode.Impulse);
                }
            }
        }
        else
        {
            // Spawn specific food type
            for (int i = 0; i < foodCount; i++)
            {
                GameObject foodInstance = Instantiate(foods[index], position, Quaternion.identity);
                Rigidbody foodRB = foodInstance.GetComponent<Rigidbody>();

                if (foodRB != null)
                {
                    float magnitude = maxForce * Random.Range(0.6f, 1f);
                    float xDirection = Random.Range(-0.1f, 0.1f);
                    foodRB.AddForce(new Vector3(xDirection, 0, 1) * magnitude, ForceMode.Impulse);
                }
            }
        }
    }
    
    public void OnFeedInput(InputAction.CallbackContext ctx)
    {
        // Get the key name
        string keyName = ctx.control.name;
        
        // Special handling for Z key (tap to throw, hold to sprint)
        if (keyName == "z")
        {
            if (ctx.started)
            {
                // Z key pressed down - start tracking
                isHoldingZ = true;
                zKeyPressTime = Time.time;
            }
            else if (ctx.canceled)
            {
                // Z key released
                isHoldingZ = false;
                
                // Reset speed multiplier
                if (playerMovement != null)
                {
                    playerMovement.SetSpeedMultiplier(1.0f);
                }
                
                // Check if it was a quick tap
                float holdDuration = Time.time - zKeyPressTime;
                if (holdDuration < tapThreshold)
                {
                    // It was a tap - throw food
                    FeedAnimal(0, 3, false);
                }
                // If held longer, don't throw food (was just sprinting)
            }
        }
        else
        {
            // For X, C, and Space - normal behavior (throw on press)
            if (ctx.started)
            {
                SelectFood(keyName);
            }
        }
    }
    
    private void SelectFood(string keyName)
    {
        Debug.Log($"Keyname: {keyName}");
        switch (keyName)
        {
            case "x":
                FeedAnimal(1, 3, false);
                break;

            case "c":
                FeedAnimal(2, 3, false);
                break;
                
            case "space":
                FeedAnimal(0, 99, true); // Changed to use index 0 and fixed allFood parameter
                break;
        }
    }
}