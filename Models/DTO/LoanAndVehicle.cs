using AnalisisProyecto.Models.DB;

namespace AnalisisProyecto.Models.DTO
{
    public class LoanAndVehicle
    {
        public int Id { get; set; }

        public int? IdLoan { get; set; }

        public int? IdUser { get; set; }

        public int? ActivityType { get; set; }

        public string? Responsible { get; set; }

        public string? State { get; set; }

        public string? Destination { get; set; }

        public string? StartingPlace { get; set; }

        public string? ExitHour { get; set; }

        public string? ReturnHour { get; set; }

        public int? PersonQuantity { get; set; }

        public string? UnityOrCarrer { get; set; }

        public string? AssignedVehicle { get; set; }

        public bool Active { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public LoanAndVehicle(int id, int? idLoan, int? idUser, int? activityType, string? responsible, string? state, string? destination, string? startingPlace, string? exitHour, string? returnHour, int? personQuantity, string? unityOrCarrer, string? assignedVehicle, bool active, DateTime? startDate, DateTime? endDate)
        {
            Id = id;
            IdLoan = idLoan;
            IdUser = idUser;
            ActivityType = activityType;
            Responsible = responsible;
            State = state;
            Destination = destination;
            StartingPlace = startingPlace;
            ExitHour = exitHour;
            ReturnHour = returnHour;
            PersonQuantity = personQuantity;
            UnityOrCarrer = unityOrCarrer;
            AssignedVehicle = assignedVehicle;
            Active = active;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
