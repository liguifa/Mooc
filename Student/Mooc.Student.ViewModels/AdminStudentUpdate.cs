using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentClient.ViewModels
{
    public class AdminStudentUpdate
    {
        public Guid StudentId { get; set; }

        public bool IsUpdate { get; set; }

        public string Error { get; set; }
    }
}
