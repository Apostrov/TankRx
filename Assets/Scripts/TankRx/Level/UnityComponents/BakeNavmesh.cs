using Unity.AI.Navigation;
using UnityEngine;

namespace TankRx.Level.UnityComponents
{
    public class BakeNavmesh : MonoBehaviour
    {
        [SerializeField] private NavMeshSurface _surface;

        private void Start()
        {
            _surface.BuildNavMesh();
        }
    }
}