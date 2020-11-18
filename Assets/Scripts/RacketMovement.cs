using UnityEngine;

public class RacketMovement : MonoBehaviour
{
    private MoveByKeyboard _keyboardMove;
    private MoveByMouse _mouseMove;

    private readonly UserInput_Mouse _userInputMouse = new UserInput_Mouse();
    private Vector3 _oldMousePos;

    void Start()
    {
        _keyboardMove = GetComponent<MoveByKeyboard>();
        _mouseMove = GetComponent<MoveByMouse>();
        _oldMousePos = _userInputMouse.GetMousePosition();
    }

    void FixedUpdate()
    {
        if (!GameController.Instance.IsPaused)
        {
            _keyboardMove.MoveRacket();

            if (IsMouseMoves(_oldMousePos, _userInputMouse.GetMousePosition()))
            {
                _mouseMove.MoveRacket();
            }

            _oldMousePos = _userInputMouse.GetMousePosition();
        }
    }

    bool IsMouseMoves(Vector3 oldPos, Vector3 newPos)
    {
        return oldPos != newPos;
    }
}
