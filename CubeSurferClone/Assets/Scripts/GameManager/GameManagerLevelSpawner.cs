using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Level;

namespace GameManager
{
    public class GameManagerLevelSpawner : GameManager
    {
        public void SpawnLevel(int index)
        {
            LevelLoader levelLoader = new LevelLoader();
            GameObject level = Instantiate(levelLoader.level(index));
        }
    }
}
