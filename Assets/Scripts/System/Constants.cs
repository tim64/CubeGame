using UnityEngine;

public class Constants : MonoBehaviour
{
    #region PlayerSettings
    //Strings
    public const string PLAYER_NAME = "Player";

    //Physics
    public const int FORCE = 100;
    public const int DOUBLEJUMP_FORCE = 200;
    public const float NORMAL_BOOST_X = 1.1f;
    public const float NORMAL_BOOST_Y = 1.1f;

    //Player reaction
    public const int MIN_SWAP_Z = 160;
    public const int MAX_SWAP_Z = 200;
    
    //Small cube
    public const float SMALL_BOOST_X = 0.5f;
    public const float SMALL_BOOST_Y = 1f;

    //Sound
    public const float PITCH_JUMP_LEVEL = 1.2f;

    //Controls
    public const KeyCode CONTROL_LEFT = KeyCode.LeftArrow;
    public const KeyCode CONTROL_RIGHT = KeyCode.RightArrow;

    #endregion




}
