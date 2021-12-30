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
        public DateRange DateRange { get; set; }

        public News()
        {

        }

        public News(string title, string text, DateTime start, DateTime end)
        {
            Title = title;
            Text = text;
            DateRange = new DateRange(start, end);
        }

        public News(long id, string title, string text, DateTime start, DateTime end)
        {
            Id = id;
            Title = title;
            Text = text;
            DateRange = new DateRange(start, end);
        }
    }
}
