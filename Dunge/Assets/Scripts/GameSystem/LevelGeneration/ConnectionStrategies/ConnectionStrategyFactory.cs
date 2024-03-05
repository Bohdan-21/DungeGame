using Scripts.GameSystem.LevelGeneration.DataChunk;
using Scripts.GameSystem.LevelGeneration.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.GameSystem.LevelGeneration.ConnectionStrategies
{
    public class ConnectionStrategyFactory : MonoBehaviour
    {
        public List<ConnectionStrategy> strategies;

        public List<TypeChunkConnection> GetTypeChunkConnection(TypeConnectionForCell typeConnectionForCell)
        {
            List<TypeChunkConnection> connections = new List<TypeChunkConnection>();

            foreach (ConnectionStrategy strategy in strategies)
            {
                if (strategy.CanConnect(typeConnectionForCell))
                    connections.Add(strategy.TypeChunkConnection);
            }
            if (connections.Count != 0)
                return connections;
            return null;
        }
    }
}
