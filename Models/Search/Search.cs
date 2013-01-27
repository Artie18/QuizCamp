using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Store;
using Directory = System.IO.Directory;

namespace QuizCamp.Models.Search
{
    public class Search : DatabaseInitializer
    {
        public Search()
        {
            
        }
    }
}