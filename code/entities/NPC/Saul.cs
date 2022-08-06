using Sandbox;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

[Spawnable]
[Library("npc_saul", Title = "saul")]
public partial class Saul : NPC
{
	public override float Speed => 500;
	public override string ModelPath => "models/saul_npc/saul_npc.vmdl";
	public override float SpawnHealth => 50;
	public override bool HaveDress => false;
	private Sound SaulSnd;

	Player Target;

	public override void Spawn()
	{
		base.Spawn();
		SaulSnd = base.PlaySound( "saul_full" );
	}

	public override void TakeDamage( DamageInfo info )
	{
		
	}

	private void FindTarget()
	{
		var rply = All.OfType<Player>().ToArray();

		Target = rply[Rand.Int(0, rply.Count() - 1)];
	}

	public override void OnTick()
	{
		if (Target == null || Target.LifeState == LifeState.Dead)
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
		if (Target == null || Target.LifeState == LifeState.Dead) return;
		if (Target.Position.Distance(Position) < 100)
		{
			MeleeStrike(113, 1.5f);
		}
	}

	public override void OnKilled()
	{
		base.OnKilled();
		SaulSnd.Stop();
		PlaySound( "saulfirstnote" );
	}
}
