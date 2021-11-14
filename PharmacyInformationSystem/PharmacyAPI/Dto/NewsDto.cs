using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PharmacyClassLib.Model;

namespace PharmacyAPI.Dto
{
    public class NewsDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DurationStart { get; set; }
        public DateTime DurationEnd { get; set; }

        public NewsDto() { }

        public NewsDto(string title, string text, DateTime durationStart, DateTime durationEnd)
        {
            Title = title;
            Text = text;
            DurationStart = durationStart;
            DurationEnd = durationEnd;
        }
        public NewsDto(long id, string title, string text, DateTime durationStart, DateTime durationEnd)
        {
            Id = id;
            Title = title;
            Text = text;
            DurationStart = durationStart;
            DurationEnd = durationEnd;
        }
    }
}
