using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.StaticData.SystemConfigData
{
    [CreateAssetMenu(fileName = "ProjectGlobalSettings", menuName = "StaticData/SystemConfigData/ProjectGlobalSettings")]
    //TODO: возможно нужно будет переименовать
    public class ProjectGlobalSettings : ScriptableObject
    {
        public string StartRoom;
        public string FightRoom;
    }
}
