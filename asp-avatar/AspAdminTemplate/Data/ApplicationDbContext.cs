using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AspAdminTemplate.Models;
using AspAdminTemplate.Models.avatar;
using AspAdminTemplate.ViewModels;

namespace AspAdminTemplate.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,string>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}

		public DbSet<forms> forms { get; set; }
		public DbSet<category> Category { get; set; }
		public DbSet<subCategory> subCategory { get; set; }
	

		
	}
}
