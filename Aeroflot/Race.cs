//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Aeroflot
{
    using System;
    using System.Collections.Generic;
    
    public partial class Race
    {
        public int RaceID { get; set; }
        public string ArrivePlace { get; set; }
        public System.TimeSpan DepartureTime { get; set; }
        public System.TimeSpan ArriveTime { get; set; }
        public int FreePlaceCount { get; set; }
        public string AirplaneKind { get; set; }
        public int AirplaneCapacity { get; set; }
    }
}
