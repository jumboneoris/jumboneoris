using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Data;

namespace Nop.Plugin.Widgets.HelloWorld.Data
{
    public class HelloWorldObjectContext : DbContext, IDbContext
    {
        #region Constructor
        public HelloWorldObjectContext(string nameOrConnectionString) : base(nameOrConnectionString) { }
        #endregion

        #region Utilities
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new HelloWorldMap());
            base.OnModelCreating(modelBuilder);
        }
        #endregion

        #region Methods
        public string CreateDatabaseScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }

        IDbSet<TEntity> IDbContext.Set<TEntity>()
        {
            return base.Set<TEntity>();
        }

        public void Install()
        {
            //Create the table
            var dbScript = CreateDatabaseScript();
            Database.ExecuteSqlCommand(dbScript);
            SaveChanges();
        }

        public void Unistall()
        {
            //drop the table
            var tableName = this.GetTableName<HelloWorld.Domain.HelloWorldRecord>();
            this.DropPluginTable(tableName);
        }

        // Execute stores procedure and load a list of entities at the end
        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        /* 
        Creates a raw SQL query that will return elements of the given generic type.  
        The type can be any type that has properties that match the names of the columns returned from the query, 
        or can be a simple primitive type. The type does not have to be an entity type. 
        The results of this query are never tracked by the context even if the type of object returned is an entity type.*/
        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        // Executes the given DDL/DML command against the database.
        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = default(int?), params object[] parameters)
        {
            throw new NotImplementedException();
        }

        // Detach an entity
        public void Detach(object entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            ((IObjectContextAdapter)this).ObjectContext.Detach(entity);
        }
        #endregion

        #region Propiedades
        public bool ProxyCreationEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool AutoDetectChangesEnabled { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        #endregion
    }
}
