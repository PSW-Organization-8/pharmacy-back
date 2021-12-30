using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyClassLib.Model
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Title { get; set; }
        public bool Read { get; set; }
        public string ContentNotification { get; set; }
        public string FileName { get; set; }

        public Notification() { }

        public Notification(long id, string title,bool read,string contents,string files)
        {
            Id = id;
            Title = title;
            Read = read;
            ContentNotification = contents;
            FileName = files;
        }

    }
}
