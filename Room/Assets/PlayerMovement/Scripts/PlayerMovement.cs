using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController _charancter;
    [SerializeField] private float _speed;
    [SerializeField] private float _gravity;
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

    protected void Update()
    {
        _charancter.Move(MoveDirection * _speed * Time.deltaTime);
        AppplyGravitation();
    }

    private void AppplyGravitation()
    {
        _charancter.Move(Physics.gravity.normalized * _gravity);
    }
}
