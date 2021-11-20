using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyClassLib.Model
{
    public class Response
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ObjectionIdFromHospitalDatabase { get; set; }
        public string HospitalName { get; set; }
        public string TextResponse { get; set; }

        public Response() { }

        public Response(long id, long objectioHospitalId, string text, string name)
        {

            TextResponse = text;
            HospitalName = name;
            Id = id;
            ObjectionIdFromHospitalDatabase = objectioHospitalId;

        }
        public Response(long objectioHospitalId, string text, string name)
        {

            TextResponse = text;
            HospitalName = name;
            ObjectionIdFromHospitalDatabase = objectioHospitalId;

        }
    }
}
