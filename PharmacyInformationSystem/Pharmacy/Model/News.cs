using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PharmacyClassLib.Model
{
    public class News
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DurationStart { get; set; }
        public DateTime DurationEnd { get; set; }

        public News()
        {

        }

        public News(string title, string text, DateTime start, DateTime end)
        {
            Title = title;
            Text = text;
            DurationStart = start;
            DurationEnd = end;
        }

        public News(long id, string title, string text, DateTime start, DateTime end)
        {
            Id = id;
            Title = title;
            Text = text;
            DurationStart = start;
            DurationEnd = end;
        }
    }
}
