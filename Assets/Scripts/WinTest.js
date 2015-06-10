#pragma strict

public var levelToUnlockForTest : int = 0;

function Start()
{
    PlayerPrefs.SetInt("SavedLevel", levelToUnlockForTest);
} 