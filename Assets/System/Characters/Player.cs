using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public PlayerDef info;
    private Rigidbody2D Rb;
    private Vector2 velocity;
    private Vector3 MousePos;
    private Vector2 SelectedTile;

    public void CreatePlayer()
    {
        Rb = GetComponent<Rigidbody2D>();
        info = new PlayerDef("temp", this.gameObject, new Dictionary<string, float>
        {
            { "Health", 100 },
            { "Stamina", 100 },
            { "MoveSpeed", 1},
            { "Damage", 10 },
        });
    }

    private void Start()
    {
        CreatePlayer();
    }

    private void FixedUpdate()
    {
        Rb.MovePosition(Rb.position + velocity * Time.fixedDeltaTime * info.moveSpeed.GetValue());
    }

    //controls
    public void OnMove(InputValue value)
    {
        
        velocity = value.Get<Vector2>();
        
    }
    public void OnMousePos(InputValue value)
    {
        MousePos = Camera.main.ScreenToWorldPoint( value.Get<Vector2>());
       // Debug.Log(MousePos);
    }

    public void OnLeftMouse()
    {//surfaceMap
        WorldData.CheckForResource(((int)MousePos.x), ((int)MousePos.y));
       //bool check= WorldData.surfaceMap.CheckLayer(1, ((int)MousePos.x), ((int)MousePos.y)) ==;

    }







}
