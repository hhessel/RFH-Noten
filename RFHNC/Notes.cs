using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace RFHNC
{
    [Serializable]
    public class Semester 
    {
        public String semester { get; set; }
        public List<Note> noten { get; set; }
    }

    [Serializable]
    public class Note {
        public String modulbezeichnung { get; set; }
        public String note { get; set; }
        public bool changed { get; set; }
    }
}
