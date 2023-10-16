using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Vector3Int gridPosition;
    private Vector3Int startGridPosition;
    private Vector3Int gridMoveDirection;

    private float horizontalInput, verticalInput;

    private float gridMoveTimer;
    private float gridMoveTimerMax = 1f;
    private List<Vector3Int> snakeMovePositionsList;

    private void Awake()
    {
        startGridPosition = new Vector3Int(2, 1, 0);
        gridPosition = startGridPosition;

        gridMoveDirection = new Vector3Int(0, 1, 0);
        transform.eulerAngles = Vector3.zero;

       // snakeMovePositionsList = new List<Vector3Int>();
    }
    private void Update()
    {
        HandleMoveDirection();
        HandleGridMovement();
    }

    private void HandleGridMovement()
    {
        gridMoveTimer += Time.deltaTime; // delta entre un frame y el siguiente
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridMoveTimer -= gridMoveTimerMax;

            snakeMovePositionsList.Insert(0, gridPosition);
            gridPosition += gridMoveDirection;

            /*transform.position = new Vector3(gridPosition.x, gridPosition.y, 0);
            transform.eulerAngles = new Vector3(0, 0, GetAngleFromVector(gridMoveDirection));*/

          
        }
    }
   
    
    //Q KEY --> Left-up (1,2)
    //A KEY --> Left-down (1,0)
    //E KEY --> Right-up (3,2)
    //D KEY --> Right-up (3,0)
    private void HandleMoveDirection()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Cambio dirección hacia arriba (right-up)
        if (verticalInput  > 1)  //
        {
            if (gridMoveDirection.x != 1) 
            {
               
                gridMoveDirection.x = 3;
                gridMoveDirection.y = 2;
            }
        }

        // Cambio dirección hacia abajo (left-up)
        if (verticalInput > 0)
        {
            if (gridMoveDirection.x != 0)
            {
                gridMoveDirection.x = 1;
                gridMoveDirection.y = 2;
            }
        }

        // Cambio dirección hacia derecha (right-down)
        if (horizontalInput > 2)
        {
            if (gridMoveDirection.y != 0)
            {
                gridMoveDirection.x = 3;
                gridMoveDirection.y = 0;
            }
        }

        // Cambio dirección hacia izquierda (left-down)
        if (horizontalInput > 0)
        {
            if (gridMoveDirection.y != 0)
            {
                gridMoveDirection.x = 1;
                gridMoveDirection.y = 0;
            }
        }
    }

    

}
