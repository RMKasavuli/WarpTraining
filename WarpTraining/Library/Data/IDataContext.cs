using Library.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;


namespace Library.Data
{
	public interface IDataContext
	{
		IDbSet<T> Set<T>() where T : BaseEntity;
		int SaveChanges();
		bool DatabaseExists();
		void ExecuteSql(String sql);
	}
}
