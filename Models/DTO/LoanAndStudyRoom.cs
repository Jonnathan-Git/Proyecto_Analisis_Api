using AnalisisProyecto.Models.DB;

namespace AnalisisProyecto.Models.DTO
{
    public class LoanAndStudyRoom
    {
        public int Id { get; set; }

        public int? NumberOfPeople { get; set; }

        public int? LoanId { get; set; }


        public int? IdUserLibrary { get; set; }

        public int? StudyRoomId { get; set; }

        public TimeSpan? ReturnHour { get; set; }

        public TimeSpan? EndHour { get; set; }


        public bool Active { get; set; }
        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public LoanAndStudyRoom(int id, int? numberOfPeople, int? loanId, int? idUserLibrary, int? studyRoomId, TimeSpan? returnHour, TimeSpan? endHour, bool active, DateTime? startDate, DateTime? endDate)
        {
            Id = id;
            NumberOfPeople = numberOfPeople;
            LoanId = loanId;
            IdUserLibrary = idUserLibrary;
            StudyRoomId = studyRoomId;
            ReturnHour = returnHour;
            EndHour = endHour;
            Active = active;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
