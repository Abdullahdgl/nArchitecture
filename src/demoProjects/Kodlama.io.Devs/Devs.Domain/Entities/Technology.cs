using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devs.Domain.Entities
{
	public class Technology:Entity
	{
		public int SPLId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public virtual SoftwareProgrammingLanguage ?	 SoftwareProgrammingLanguage { get; set; }

		public Technology()
		{
		}

		public Technology(int id, int sPLId, string name, string description)
		{
			Id = id;
			SPLId = sPLId;
			Name = name;
			Description = description;
			
		}
	}
}
