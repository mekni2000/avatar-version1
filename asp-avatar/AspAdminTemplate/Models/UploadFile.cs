using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AspAdminTemplate.Models
{
	public class UploadFile
	{
		public int Id { get; set; }

		[StringLength(255)]
		public string Name { get; set; }

		[StringLength(255)]
		public string Hash { get; set; }

		[StringLength(10)]
		public string Ext { get; set; }

		[StringLength(255)]
		public string Mime { get; set; }

		[StringLength(10)]
		public string Size { get; set; }
		public int IsReference { get; set; }
		[StringLength(500)]
		public string URL { get; set; }
		[JsonIgnore]
		public int Temporary { get; set; } = 0;
		public DateTime CreatedAt { get; internal set; }

		[JsonIgnore]
		[NotMapped]
		public static DateTime Timeout => new DateTime(0).AddDays(30);
		[JsonIgnore]
		[NotMapped]
		public bool Expired => Temporary > 0 && CreatedAt.Ticks + Timeout.Ticks < DateTime.Now.Ticks;
	}
}
