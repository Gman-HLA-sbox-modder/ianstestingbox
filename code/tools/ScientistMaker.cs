namespace Sandbox.Tools
{
	[Library( "tool_wander", Title = "Scientist Maker", Description = "what", Group = "AAAAAA" )]
	public partial class WanderTool : BaseTool
	{
		PreviewEntity previewModel;
		bool massless = true;

		public override void CreatePreviews()
		{
			if ( TryCreatePreview( ref previewModel, "models/scientist/scientist.vmdl" ) )
			{
				previewModel.RotationOffset = Rotation.FromAxis( Vector3.Right, -90 );
			}
		}

		protected override bool IsPreviewTraceValid( TraceResult tr )
		{
			if ( !base.IsPreviewTraceValid( tr ) )
				return false;

			if ( tr.Entity is Wandertest )
				return false;

			return true;
		}

		public override void Simulate()
		{
			if ( !Host.IsServer )
				return;

			using ( Prediction.Off() )
			{
				if ( !Input.Pressed( InputButton.PrimaryAttack ) )
					return;

				var startPos = Owner.EyePosition;
				var dir = Owner.EyeRotation.Forward;

				var tr = Trace.Ray( startPos, startPos + dir * MaxTraceDistance )
					.Ignore( Owner )
					.Run();

				if ( !tr.Hit )
					return;

				if ( !tr.Entity.IsValid() )
					return;

				var attached = !tr.Entity.IsWorld && tr.Body.IsValid() && tr.Body.PhysicsGroup != null && tr.Body.GetEntity().IsValid();

				CreateHitEffects( tr.EndPosition );

				var ent = new Wandertest
				{
					Position = tr.EndPosition,
					Rotation = Rotation.LookAt( tr.Normal, dir ) * Rotation.From( new Angles( 90, 0, 0 ) ),
				};

				if ( attached )
				{
					ent.SetParent( tr.Body.GetEntity(), tr.Body.GroupName );
				}

				ent.SetModel( "models/scientist/scientist.vmdl" );
			}
		}
	}
}
