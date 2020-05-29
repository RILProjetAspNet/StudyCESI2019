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

        [Column("Subject_SubjectId")]
        [DisplayName("Sujet")]
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }

        [DisplayName("Nb de questions")]
        [Range(1, 100)]
        public int NumberQuestions { get; set; }

        [DisplayName("Durée (en mn)")]
        public int Duration { get; set; }

        [DisplayName("Nb de tentatives autorisées")]
        [Range(1, 10)]
        public int  NumberTriesAllow { get; set; }

        [DisplayName("Date limite")]
        public DateTime EndDate { get; set; }


        [Column("AspNetUsers_Id")]
        public string UserId { get; set; }
        public User User { get; set; }

        [DisplayName("Date de création")]
        public DateTime CreationDate { get; set; }
    }
}
