using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BaseController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody2D;
    protected AnimationHandler animationHandler;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    protected Vector2 lookDirection = Vector2.zero;
    public Vector2 Lookdirection { get { return lookDirection; } }


    protected virtual void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }
    
    protected virtual void Start()
    {

    }


    protected virtual void Update()
    {
        HandleAction();
        Rotate(lookDirection);
    }

    protected virtual void HandleAction()
    {

    }

    private void Movement(Vector2 direction)
    {
        direction = direction * 5;

        _rigidbody2D.velocity = direction;
        animationHandler.Move(direction);
    }

    private void Rotate(Vector2 direction)
    {
        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bool isLeft = Mathf.Abs(rotZ) > 90f;

        characterRenderer.flipX = isLeft;
    }
}
