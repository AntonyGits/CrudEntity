using CrudEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudEntity
{
  public  class ModelContext:DbContext
    
    {
        public ModelContext() : base("name=cn"){ }
        public DbSet<Presidents> PresidentsList { get; set; }

   
        
    }
}
