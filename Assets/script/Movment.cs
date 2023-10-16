using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Movment : MonoBehaviour
{
    // Corrección María

    private float Timer;
    private float TimerMax = 1f;

    private Vector2Int position2D;
    private Vector2Int moveDirection;

    private void Awake()
    {
        Timer = 0;
        position2D=Vector2Int.zero;
        transform.position=new Vector3(position2D.x, position2D.y,0);
        //direccion base
        moveDirection=new Vector2Int(1,1);
    }
    private void Update()
    {
        HandleInput();

        Timer += Time.deltaTime; // delta --> entre un frame y el siguiente
        if (Timer >= TimerMax)
        {
            Timer -= TimerMax; // si me paso de decimal, se guardan y se siguen sumando al timer
            position2D += moveDirection;//esta me hace moverme 
            transform.position = new Vector3(position2D.x, position2D.y, 0); //cada vez que te mueves, esta es tu coordenada
        }
    }

    private void HandleInput()
    {
        Vector2Int previousDirection = moveDirection; //almacena moveirection, 
        bool validNewPosition = true; //validarme la direccion respeto a la aterior
        //left up
        if (Input.GetKeyDown(KeyCode.Q)) 
        {
            moveDirection=new Vector2Int(-1,1);
            validNewPosition= IsNewDirectionValid(previousDirection,moveDirection); 
        }

        //right up
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            moveDirection = new Vector2Int(1, 1);
            validNewPosition = IsNewDirectionValid(previousDirection, moveDirection);
        }

        //left own
        if (Input.GetKeyDown(KeyCode.A)) 
        {
            moveDirection = new Vector2Int(-1, -1);
            validNewPosition = IsNewDirectionValid(previousDirection, moveDirection);
        }

        //right down
        if (Input.GetKeyDown(KeyCode.D)) 
        {
            moveDirection = new Vector2Int(1, -1);
            validNewPosition = IsNewDirectionValid(previousDirection, moveDirection);
        }

        if (validNewPosition) { }
    }

    private bool IsNewDirectionValid(Vector2Int previousDirection,Vector2Int newDirection) //compruebo 
    {
        return (newDirection != -previousDirection); //si mi anterior direccion es la opuesta a la nueva que quiero tomar, true y no me deja pasar
    }
}
