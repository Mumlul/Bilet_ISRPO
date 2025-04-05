using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Билет_5
{
    public class Task
    {
        private int id;
        private string name;
        private string isp;
        private string status;


        public int Id { get { return id; } }

        public string Name { get { return name; } }
        public string Isp { get { return isp; } }
        public string Status { get { return status; } set { status = value; } }

        public Task(int id_,string name_,string isp_,string status_)
        {
            this.id = id_;
            this.name = name_;
            this.isp = isp_;
            this.status = status_;
        }
    }
}
