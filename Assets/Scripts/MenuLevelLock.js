#pragma strict

public var level1Unlocked : GameObject;
public var level1Locked : GameObject;
public var level2Unlocked : GameObject;
public var level2Locked : GameObject;
public var level3Unlocked : GameObject;
public var level3Locked : GameObject;
public var level4Unlocked : GameObject;
public var level4Locked : GameObject; 

public var levelReached1 : boolean = false;
public var levelReached2 : boolean = false;
public var levelReached3 : boolean = false;
public var levelReached4: boolean = false;
public var levelReached0 : boolean = false;
private var savedLevel : int = 0; 

public var collider1 = level1Unlocked.GetComponent(BoxCollider);
public var collider2 = level2Unlocked.GetComponent(BoxCollider);
public var collider3 = level3Unlocked.GetComponent(BoxCollider);
public var collider4 = level4Unlocked.GetComponent(BoxCollider);

function Start () {
//If we have a savefile
if(PlayerPrefs.HasKey)
{
    // Grab the saved data, use it to load that level
    savedLevel = PlayerPrefs.GetInt("SavedLevel");
}
//if no saved data yet
//set some to unlock level 01 by default
else
{
    PlayerPrefs.SetInt("SavedLevel", 0);
    savedLevel = PlayerPrefs.GetInt("SavedLevel");
}
if(savedLevel == 0)
{
    levelReached0 = true;
}
if(savedLevel == 1) //check what level we've progressed to so far
{
    levelReached1 = true;
}
if(savedLevel == 2)
{
    levelReached2 = true;
}
if(savedLevel == 3)
{
    levelReached3 = true;
}
if(savedLevel == 4)
{
    levelReached4 = true;
}
}


function Update ()  
{
//disable the locked texture, enable the unlocked one
//Level1 is always unlocked by default
if(levelReached1 == true)
{
    level1Unlocked.SetActive (true);
    level1Locked.SetActive(false);
    collider1.enabled = true;
    //level 02 gets unlocked here because we've beat Level01
    level2Unlocked.SetActive(true);
    level2Locked.SetActive(false);
    collider2.enabled = true;
}
//disable the level 2 lock, enable the button
if(levelReached2 == true)
{
    level1Unlocked.SetActive (true);
    level1Locked.SetActive(false);
    collider1.enabled = true;
 
    level2Unlocked.SetActive(true);
    level2Locked.SetActive(false);
    collider2.enabled = true;
    //level 03 gets unlocked here
    level3Unlocked.SetActive(true);
    level3Locked.SetActive (false);
    collider3.enabled = true;
}
//disable the level 3 lock
if(levelReached3 == true)
{
    level1Unlocked.SetActive (true);
    level1Locked.SetActive(false);
    collider1.enabled = true;
 
    level2Unlocked.SetActive(true);
    level2Locked.SetActive(false);
    collider2.enabled = true;
 
    level3Unlocked.SetActive(true);
    level3Locked.SetActive (false);
    collider3.enabled = true;
 
    //level 04 gets unlocked here because we've beat Level03
    level4Unlocked.SetActive(true);
    level4Locked.SetActive (false);
    collider4.enabled = true;
}
//if no levels have been played yet
else if(levelReached0 == true)
{
    level1Unlocked.SetActive (true);
    level1Locked.SetActive (false);
    collider1.enabled = true;
 
    level2Unlocked.SetActive (false);
    level2Locked.SetActive(true);
    collider2.enabled = false;
 
    level3Unlocked.SetActive (false);
    level3Locked.SetActive(true);
    collider3.enabled = false;
 
    level4Unlocked.SetActive (false);
    level4Locked.SetActive(true);
    collider4.enabled = false;
}       

if (Input.GetMouseButtonDown (0))
{
    //mouse click input
    var ray = Camera.main.ScreenPointToRay (Input.mousePosition);
    var hit : RaycastHit;
    if (Physics.Raycast (ray, hit, 20))
    {
         //load level when a collider is clicked
         if(hit.collider.name == "Level01_Button")
              Application.LoadLevel("platform");
 
         if(hit.collider.name == "Level02_Button")
               Application.LoadLevel("CubeFall");
 
         if(hit.collider.name == "Level03_Button")
              Application.LoadLevel("level3");
         }
    }
}