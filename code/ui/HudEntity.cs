﻿using Sandbox;
using Sandbox.UI;

namespace VrExample;

/// <summary>
/// This will project the example HUD onto your left wrist
/// </summary>
public class HealthHudEntity : WorldPanel
{
	public HealthHudEntity()
	{
		SetClass( "is-vr", true );

		StyleSheet.Load( "/ui/VRHealth.scss" );

		AddChild<VRHealth>();
	}

	public override void Tick()
	{
		base.Tick();

		if ( Local.Pawn is SandboxPlayer player )
		{
			Transform = player.LeftHand.Transform;

			//
			// Offsets
			//
			Rotation *= new Angles( -180, -90, 45 ).ToRotation();
			Position += Rotation.Forward * 5 + Rotation.Up * 6 - Rotation.Left * 12;
			WorldScale = 0.1f;
			Scale = 1.5f;

			PanelBounds = new Rect( 0, 0, 1920, 1080 );
		}
	}
}
