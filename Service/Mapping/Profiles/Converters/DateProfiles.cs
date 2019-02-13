using System;
using System.Globalization;
using AutoMapper;
using Service.Dtos.Shared;

namespace Service.Mapping.Profiles.Converters
{
    public class DateProfiles : Profile
    {
        public DateProfiles()
        {
            CreateMap<DatePeriodDto, Tuple<DateTime, DateTime>>().ConvertUsing(new PeriodTupleConverter());
        }
    }

    public class PeriodTupleConverter : ITypeConverter<DatePeriodDto, Tuple<DateTime, DateTime>>
    {
        public Tuple<DateTime, DateTime> Convert(DatePeriodDto source, Tuple<DateTime, DateTime> destination,
            ResolutionContext context)
        {
            return new Tuple<DateTime, DateTime>
            (
                DateTime.ParseExact(source.DateFrom, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                DateTime.ParseExact(source.DateTo, "dd/MM/yyyy", CultureInfo.InvariantCulture)
            );
        }
    }
}
