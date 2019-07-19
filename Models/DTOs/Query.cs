using System;
using System.Collections.Generic;

namespace PollutionQA.Models.DTOs
{
    /// <summary>
    /// Queries could be stored as json documents in a non-relational database or send to other service.
    /// </summary>
    [Serializable()]
    public class Query {
        
        public QueryDetails queryDetails { get; private set; }

        public IEnumerable<QueryResult> queryResults { get; private set; }

    }
}