using System;

namespace Game.Scripts.Data
{
	public class Resource : ICloneable
	{
		public ResourceType Type;
		public int Amount;
		public string Id;

		public Resource()
		{
			Type = ResourceType.Soft;
			Amount = 0;
		}

		public Resource(ResourceType type, int amount)
		{
			Type = type;
			Amount = amount;
		}

		public Resource(ResourceType type, string id, int amount) : this(type, amount)
		{
			Id = id;
		}

		protected bool Equals(Resource other)
		{
			return Type == other.Type && Amount.Equals(other.Amount) && Id == other.Id;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Resource) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = (int) Type;
				hashCode = (hashCode * 397) ^ Amount.GetHashCode();
				hashCode = (hashCode * 397) ^ (Id != null ? Id.GetHashCode() : 0);
				return hashCode;
			}
		}

		public object Clone()
		{
			return MemberwiseClone();
		}
	}
}