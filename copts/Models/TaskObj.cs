using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace copts.Models
{
    public class TaskObj
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }

        public int PriorityTaskId { get; set; }
        public PriorityTask PriorityTask { get; set; }

        public int StatusTaskId { get; set; }
        public StatusTask StatusTask { get; set; }
        
        public string Login { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public byte Attachment { get; set; }
    }
}
