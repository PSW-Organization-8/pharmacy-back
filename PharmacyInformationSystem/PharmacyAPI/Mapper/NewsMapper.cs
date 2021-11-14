using PharmacyAPI.Dto;
using PharmacyClassLib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyAPI.Mapper
{
    public class NewsMapper
    {
        public static News NewsDtoToNews(NewsDto dto)
        {
            return new News(dto.Id, dto.Title, dto.Text, dto.DurationStart, dto.DurationEnd);
        }

        public static NewsDto NewsToNewsDto(News news)
        {
            return new NewsDto(news.Id, news.Title, news.Text, news.DurationStart, news.DurationEnd);
        }
    }
}
