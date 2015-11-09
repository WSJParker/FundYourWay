using System;
using System.Collections.Generic;
using System.Data.Entity;
using WebMatrix.WebData;
using System.Linq;
using System.Web;
using FundYourWay.Models;

namespace FundYourWay.DAL
{
    public class FundYourWayInit : DropCreateDatabaseIfModelChanges<FundYourWayContext>
    {
        public FundYourWayInit()
        {
            if (base.GetType().IsSubclassOf(new DropCreateDatabaseIfModelChanges<FundYourWayContext>().GetType()))
            {
                WebSecurity.InitializeDatabaseConnection(
                    "FundYourWayContext",
                    "UserProfiles",
                    "UserId",
                    "UserName",
                    autoCreateTables: true
                    );
            }


        }

        protected override void Seed(FundYourWayContext context)
        {
            var userprofiles = new List<UserProfile>
            {
                new UserProfile
                {

                }

            };

            userprofiles.ForEach(u => context.UserProfiles.Add(u));
            context.SaveChanges();
            var transactions = new List<Transaction>
            {
                new Transaction
                {

                }

            };
            transactions.ForEach(t => context.Transtions.Add(t));
            context.SaveChanges();

            var projects = new List<Project>
            {

            };
            projects.ForEach(p => context.Projects.Add(p));
            context.SaveChanges();

            
        }
    }
}