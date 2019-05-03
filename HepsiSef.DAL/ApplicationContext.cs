using HepsiSef.Core.Entity;
using HepsiSef.Entity.App;
using HepsiSef.Entity.Definition;
using HepsiSef.Entity.SystemUser;
using HepsiSef.Mapping.App;
using HepsiSef.Mapping.Definition;
using HepsiSef.Mapping.SystemUser;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static HepsiSef.Core.Enums.Enums;

namespace HepsiSef.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {

        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //APP FOLDER
            new BookmarkMapping(builder.Entity<Bookmark>());
            new CategoryMapping(builder.Entity<Category>());
            new ContactMapping(builder.Entity<Contact>());
            new NewsletterMapping(builder.Entity<Newsletter>());

            //DEFINITION FOLDER
            new RecipeCategoryMapping(builder.Entity<RecipeCategory>());
            new RecipeImageMapping(builder.Entity<RecipeImage>());
            new RecipeIngredientMapping(builder.Entity<RecipeIngredient>());
            new RecipeMapping(builder.Entity<Recipe>());
            new RecipeRateMapping(builder.Entity<RecipeRate>());
            new StepMapping(builder.Entity<Step>());


            //USER FOLDER
            new ExternalLoginMapping(builder.Entity<ExternalLogin>());
            new UserMapping(builder.Entity<User>());
            new ForgatPasswordMapping(builder.Entity<ForgatPassword>());

        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            if (ChangeTracker.HasChanges())
            {
                foreach (var item in ChangeTracker.Entries())
                {
                    var temp = (BaseEntity)item.Entity;
                    switch (item.State)
                    {
                        case EntityState.Detached:
                            break;
                        case EntityState.Unchanged:
                            break;
                        case EntityState.Added:
                            temp.RecordStatus = RecordStatus.Active;
                            temp.CreateDate = DateTime.UtcNow;
                            temp.UpdateDate = DateTime.UtcNow;
                            break;
                        case EntityState.Deleted:
                            temp.RecordStatus = RecordStatus.Deleted;
                            temp.UpdateDate = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            temp.UpdateDate = DateTime.UtcNow;
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
