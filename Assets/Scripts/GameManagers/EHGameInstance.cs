using System;
using UnityEngine;

[System.Serializable]
public struct FWorldSettings
{
    public EHPlayerController PlayerController;
    public EHPlayerState PlayerState;
    public EHPlayerCharacter PlayerCharacter;

    public EHGameState GameState;
}

public class EHGameInstance : MonoBehaviour
{
    private static EHGameInstance instance;

    public static EHGameInstance Instance
    {
        get
        {
            if (instance != null)
            {
                return instance;
            }
            instance = GameObject.FindObjectOfType<EHGameInstance>();
            return instance;
        }
    }

    public FWorldSettings WorldSetting;
    
    #region player variables

    public EHPlayerState PlayerState { get; private set; }
    public EHPlayerController PlayerController { get; private set; }
    public EHPlayerCharacter PlayerCharacter { get; private set; }
    
    public EHGameState GameState { get; private set; }
    #endregion player variables


    private void Awake()
    {
        if (!instance)
        {
            instance = this;
            InitializeWorldSettings(WorldSetting);
            return;
        }
        instance.InitializeWorldSettings(WorldSetting);
        Destroy(this.gameObject);
    }

    private void InitializeWorldSettings(FWorldSettings WorldSettings)
    {
        // PlayerState = Instantiate(WorldSettings.PlayerState);
        // PlayerController = Instantiate(WorldSetting.PlayerController);
        // PlayerCharacter = Instantiate(WorldSetting.PlayerCharacter);
        PlayerState = WorldSetting.PlayerState;
        PlayerController = WorldSetting.PlayerController;
        PlayerCharacter = WorldSetting.PlayerCharacter;

        GameState = WorldSettings.GameState;
    }
}
