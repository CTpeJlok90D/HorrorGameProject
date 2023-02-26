using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _charancter;
    [SerializeField] private float _speed;

    public Vector3 MoveDirection
    {
        get
        {
            Vector3 result = InputSingletone.Instance.Player.Move.ReadValue<Vector2>();
            result = new Vector3(result.x, 0, result.y);
            result = _charancter.transform.TransformDirection(result);
            return result;
        }
    }

    protected void FixedUpdate()
    {
        _charancter.Move(MoveDirection * _speed * Time.fixedDeltaTime);
    }
}
