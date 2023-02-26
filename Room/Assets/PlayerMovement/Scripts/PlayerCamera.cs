using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _character;
    [SerializeField] private float _maxAngle;

    public Vector2 Look => InputSingletone.Instance.Player.Look.ReadValue<Vector2>();

    protected void Update()
    {
        RotateCharacter(Look.x);
        RotateCamera(Look.y);
    }

    public void RotateCharacter(float offcet)
    {
        Vector3 rotateOffcet = new Vector3(0, offcet, 0);
        _character.transform.Rotate(rotateOffcet);
    }

    public void RotateCamera(float offcet)
    {
        float newRotateAnge = _camera.eulerAngles.x - offcet;
        if (newRotateAnge > 180 && newRotateAnge < 360 - _maxAngle)
        {
            newRotateAnge = 360 - _maxAngle;
        }
        if (newRotateAnge < 180 && newRotateAnge > _maxAngle)
        {
            newRotateAnge = _maxAngle;
        }

        _camera.eulerAngles = new Vector3(newRotateAnge, _camera.eulerAngles.y, _camera.eulerAngles.z);
    }
}