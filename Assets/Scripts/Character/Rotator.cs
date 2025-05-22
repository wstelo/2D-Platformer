using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Character _character;

    private void Awake()
    {
        _character = GetComponent<Character>();
    }

    private void FixedUpdate()
    {
        float horizontalDirection = _character.HorizontalDirection;

        if(horizontalDirection > 0)
        {
            transform.rotation = Quaternion.identity;
        }
        else if(horizontalDirection < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    public void RotateCharacter()
    {
        if(transform.rotation.y == 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
        else
        {
            transform.rotation = Quaternion.identity;
        }
    }
}
