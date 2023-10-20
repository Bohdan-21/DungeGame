using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.StaticData.ProjectGlobalSettings
{
    [CreateAssetMenu(fileName = "ProjectGlobalSettings", menuName = "StaticData/ProjectGlobalSettings")]
    public class ProjectGlobalSettings : ScriptableObject
    {
        public string StartRoom;

        public List<string> DungeLevels;
    }
}
