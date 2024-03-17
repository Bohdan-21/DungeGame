using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.StaticData.GameConfigData.Environment
{
    [CreateAssetMenu(fileName = "EnvironmentData", menuName = "StaticData/GameConfigData/Environment/EnvironmentData")]
    public class EnvironmentData : ScriptableObject
    {
        [SerializeField] private int _spikesDamage;

        public int SpikesDamage { get => _spikesDamage; }
    }
}
