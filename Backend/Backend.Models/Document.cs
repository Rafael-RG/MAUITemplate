using System.Collections.Generic;

namespace Backend.Models
{
    /// <summary>
    /// Documents info
    /// </summary>
    public class Document : BaseModel
    {
        public string DocumentId { get; set; }

        public string Title { get; set; }

        public string File { get; set; }

    }
    
}


