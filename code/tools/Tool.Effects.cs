using System;
using Sandbox;
using Sandbox.UI;

public partial class Tool
{
	[ClientRpc]
	public void CreateHitEffects( Vector3 hitPos )
	{
		var particle = Particles.Create( "particles/tool_hit.vpcf", hitPos  );
		particle.SetPosition( 0, hitPos );
		particle.SetPosition( 2, new Vector3() );

		var beam = Particles.Create( "particles/tool_tracer.vpcf", hitPos );
		beam.SetEntityAttachment( 0, EffectEntity, "muzzle", true );
		beam.SetPosition( 1, hitPos );

		PlaySound( "balloon_pop_cute" );
	}
}
