using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "STORY", menuName = "STORY")]
public class StorySave : ScriptableObject
{
    public bool OnStory = false;
    public int StoryCharacter = 0;
}
