using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InOne.TaskManager.Models.OtherModels
{
    public class UserInfo
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }

        public IEnumerable<TaskInfo> TaskInfos { get; set; }

    }
}
