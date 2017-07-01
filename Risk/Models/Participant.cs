using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace Risk.Models
{
    public class Participant
    {
        //do not set identity column, instead import from csv
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ParticipantId { get; set; }
        public string Name { get; set; }
    }
}