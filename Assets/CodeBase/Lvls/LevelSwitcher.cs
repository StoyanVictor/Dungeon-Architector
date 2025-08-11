using System.Collections.Generic;
using UnityEngine;

namespace CodeBase
{
    public class LevelSwitcher : MonoBehaviour
    {
        [SerializeField] private List<LevelData> _levels = new List<LevelData>();
        public List<LevelData> GetLevels() => _levels;
        
        private int currentLvl;
        
        public void SwitchLvl()
        {
            if(currentLvl < _levels.Count)
                currentLvl++;
        }

        public int GetCurrentLvlIndex() => currentLvl;
    }
}