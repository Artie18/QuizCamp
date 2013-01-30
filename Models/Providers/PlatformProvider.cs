using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizCamp.Models.Providers
{
    public class PlatformProvider : DatabaseInitializer
    {
        public void Add(Platform platform)
        {
            platform.PlatformId = Guid.NewGuid();
            db.Platforms.Add(platform);
            db.SaveChanges();
        }
    }
}