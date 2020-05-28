using AspAdminTemplate.Attributes.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AspAdminTemplate.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true, Inherited = false)]
	public class ForeignKeyDisplayAsAttribute : Attribute
	{
		public string CustomPropsName { get; set; }
		public string StringFormater { get; set; }

		public CRUDFlag CrudFlag { get; set; }

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="customPropsName">The Type of the passed props name must be string</param>
		/// <param name="stringFormater">StringFormater can accept any string,You can use the props that you declared in propsList by using {}, example for pros named 'Id' you can wirte a string like this 'this is an ID: {Id}'</param>
		/// <param name="CrudFlag">a flag to tell on which crud operation you want to use the formater</param>
		public ForeignKeyDisplayAsAttribute(string customPropsName = "Name", string stringFormater = "", CRUDFlag crudFlag = CRUDFlag.All)
		{
			CustomPropsName = customPropsName;
			StringFormater = stringFormater;
			CrudFlag = crudFlag;
		}
	}
}
