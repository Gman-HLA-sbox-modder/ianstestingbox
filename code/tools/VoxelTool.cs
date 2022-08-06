using System;
using System.Linq;
using Sandbox;
using Voxels;

namespace Sandbox.Tools
{
	[Library( "tool_voxels", Title = "Voxel Tool", Description = "Create Voxel Blobs", Group = "construction" )]
	public partial class VoxelTool : BaseTool
	{
		TimeSince timeSinceShoot;

		[Net] public VoxelVolume Voxels { get; private set; }

		public override void Simulate()
		{
			if ( Host.IsServer )
			{

				if ( Input.Pressed( InputButton.PrimaryAttack ) )
				{
					CreateVoxel();
				}

			}
		}

		void CreateVoxel()
		{
			Voxels = new VoxelVolume( new Vector3( 32_768f, 32_768f, 32_768f ), 256f, 4, NormalStyle.Smooth );
		}
	}
}
