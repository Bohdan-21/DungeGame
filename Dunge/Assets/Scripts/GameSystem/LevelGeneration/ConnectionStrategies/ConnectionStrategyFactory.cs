using Scripts.GameSystem.LevelGeneration.DataChunk;
using Scripts.GameSystem.LevelGeneration.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.GameSystem.LevelGeneration.ConnectionStrategies
{
    public class ConnectionStrategyFactory
    {
        private List<ConnectionStrategy> strategies = new List<ConnectionStrategy>();

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

        public void AddConnectionStrategy(ConnectionStrategy strategy)
        {
            strategies.Add(strategy);
        }
    }
}
