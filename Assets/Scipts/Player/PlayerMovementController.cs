

/******************************************************************************  
 * Class: PlayerMovementController  
 * Purpose: Controls player movement based on input.  
 * Component Of: Player GameObject  
 * Fields: 
 *   - playerSpeed (float) → Controls movement speed.  
 *   - widthOfField (float) → Prevents movement beyond boundaries.  
 *   - moveDirection (float) → Stores input direction.    
 * Behaviors:
 *   - Start() → Initializes variables.  
 *   - Update() → Executes the PlayerMovement methods per frame.
 *   - OnMovementInput() → Handles player input events.
 *   - DeterminePlayerDirection() → Assigns player's move direction -1, 1, or 0 
 *                                  to determine the direction of motion: left, 
 *                                  right, or stationary.
 *   - PlayerMovement() → Processes movement logic.
 * Access: To enforce encapsulation only OnMovementInput() is visible
 * Author: Bruce Gustin
 * Version: July 1, 2025 v. 1.0
 *******************************************************************************/



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameOfClass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
