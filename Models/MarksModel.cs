using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class MarksModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Marks_ID { get; set; }
        public int Subject_ID { get; set; }
        public int Student_ID { get; set; }
        public int Student_Marks { get; set; }
    }
}
