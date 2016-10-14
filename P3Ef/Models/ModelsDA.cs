namespace Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class ModelsDA : DbContext
    {
        // Your context has been configured to use a 'ModelsDA' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Models.ModelsDA' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ModelsDA' 
        // connection string in the application configuration file.
        public ModelsDA()
            : base("name=ModelsDA")
        {
        }

        public System.Data.Entity.DbSet<Models.Project> Projects { get; set; }

        public List<Project> ListProjects(string uid)
        {
            return Projects.Where(p => p.UId == uid).ToList();
        }

        public System.Data.Entity.DbSet<Models.Source> Sources { get; set; }

        public List<Source> ListSources(string pname)
        {
            return Sources.Where(s => s.PName == pname).ToList();
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}