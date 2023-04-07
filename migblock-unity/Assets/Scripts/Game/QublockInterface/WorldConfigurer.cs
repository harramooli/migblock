
using UnityEngine;

using Qublock.Core;

public class WorldConfigurer : MonoBehaviour {

    public Material chunkMaterial_Standard;
    public Material chunkMaterial_Fade;
    public Material chunkMaterial_Particle;

    private void Start () {

        World.chunkMaterial = chunkMaterial_Standard;
        World.fadeChunkMaterial = chunkMaterial_Fade;
        World.particleChunkMaterial = chunkMaterial_Particle;
    }
}
