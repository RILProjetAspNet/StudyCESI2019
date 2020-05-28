using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StudyCESI.Model.Entities
{
    public class Exam
    {
        public int ExamId { get; set; }

        [DisplayName("Nom de l'examen")]
        public string Name { get; set; }

        [DisplayName("Nombre de questions")]
        public int NumberQuestions { get; set; }

        [DisplayName("Durée de l'examen")]
        public int Duration { get; set; }

        [DisplayName("Nombre de tentatives autorisées")]
        public int  NumberTriesAllow { get; set; }

        [DisplayName("Date limite de l'examen")]
        public DateTime EndDate { get; set; }

        public DateTime CreationDate { get; set; }

        [Column("AspNetUsers_Id")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
