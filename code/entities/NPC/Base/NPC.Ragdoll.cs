using Sandbox;
using System.Collections.Generic;

public partial class NPC
{
	private void BecomeRagdoll( Vector3 velocity, DamageFlags damageFlags, Vector3 forcePos, Vector3 force, int bone )
	{
		// TODO - lets not make everyone write this shit out all the time
		// maybe a CreateRagdoll<T>() on ModelEntity?
		var ent = new ModelEntity();
		ent.Position = Position;
		ent.Rotation = Rotation;
		ent.PhysicsEnabled = true;
		ent.UsePhysicsCollision = true;
		ent.CopyFrom( this );
		ent.CopyBonesFrom( this );
		ent.SetRagdollVelocityFrom( this );
		ent.DeleteAsync( 20.0f );
	}
}
