using Sandbox;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

[Spawnable]
[Library( "npc_attacker", Title = "Attacker" )]
public partial class AttackerNPC : NPC
{
	public override float Speed => 200;
	public override float SpawnHealth => 50;
	public override bool HaveDress => false;

	Player Target;

	public override void Spawn()
	{
		base.Spawn();

		SetMaterialGroup( 1 );
	}

	private void FindTarget()
	{
		var rply = All.OfType<Player>().ToArray();

		Target = rply[Rand.Int( 0, rply.Count() - 1 )];
	}

	public override void OnTick()
	{
		if ( Target == null || Target.LifeState == LifeState.Dead )
			FindTarget();
		else
		{
			Steer = new NavSteer();
			Steer.Target = Target.Position;
			Steer.DontAvoidance = e => true;
		}
	}

	public override void DoMeleeStrike()
	{
		if ( Target == null || Target.LifeState == LifeState.Dead ) return;
		if ( Target.Position.Distance( Position ) < 100 )
		{
			MeleeStrike( 3, 1.5f );
		}
	}
}
